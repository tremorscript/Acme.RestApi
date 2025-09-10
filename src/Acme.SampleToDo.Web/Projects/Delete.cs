using Acme.SampleToDo.Core.ProjectAggregate;
using Acme.SampleToDo.UseCases.Projects.Delete;
using Ardalis.Result.AspNetCore;

namespace Acme.SampleToDo.Web.Projects;

/// <summary>
///   Deletes a project
/// </summary>
public class Delete(IMediator mediator) : Endpoint<DeleteProjectRequest>
{
  private readonly IMediator _mediator = mediator;

  public override void Configure()
  {
    Delete(DeleteProjectRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeleteProjectRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeleteProjectCommand(ProjectId.From(request.ProjectId));

    var result = await _mediator.Send(command);

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
