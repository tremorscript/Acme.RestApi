using Acme.SampleToDo.Core.ContributorAggregate.Events;
using Acme.SampleToDo.Core.ProjectAggregate;
using Acme.SampleToDo.Core.ProjectAggregate.Specifications;

namespace Acme.SampleToDo.Core.ContributorAggregate.Handlers;

internal class ContributorDeletedEventHandler : INotificationHandler<ContributorDeletedEvent>
{
  private readonly IRepository<Project> _repository;
  private readonly ILogger<ContributorDeletedEventHandler> _logger;

  public ContributorDeletedEventHandler(IRepository<Project> repository, ILogger<ContributorDeletedEventHandler> logger)
  {
    _repository = repository;
    _logger = logger;
  }

  public async Task Handle(ContributorDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Removing deleted contributor {contributorId} from all projects...", domainEvent.ContributorId);
    // Perform eventual consistency removal of contributors from projects when one is deleted
    var projectSpec = new ProjectsWithItemsByContributorIdSpec(domainEvent.ContributorId);
    var projects = await _repository.ListAsync(projectSpec, cancellationToken);
    foreach (var project in projects)
    {
      project.Items
        .Where(item => item.ContributorId == domainEvent.ContributorId)
        .ToList()
        .ForEach(item => item.RemoveContributor());
      await _repository.UpdateAsync(project, cancellationToken);
    }
    
  }
}
