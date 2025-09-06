using Acme.SampleToDo.Core.ContributorAggregate;

namespace Acme.Sample.ToDo.UseCases.Contributors.Commands.Create;

public class CreateContributorHandler : ICommandHandler<CreateContributorCommand, Result<int>>
{
  private readonly IRepository<Contributor> _contributorRepository;

  public CreateContributorHandler(IRepository<Contributor> contributorRepository)
  {
    _contributorRepository = contributorRepository;
  }

  public async Task<Result<int>> Handle(CreateContributorCommand request, CancellationToken cancellationToken)
  {
    var newContributor = new Contributor(request.Name);
    var createdItem = await _contributorRepository.AddAsync(newContributor, cancellationToken);

    return createdItem.Id;
  }
}
