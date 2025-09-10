using Acme.SampleToDo.Core.ProjectAggregate;
using Acme.SampleToDo.UseCases.Projects.Update;
using Ardalis.Result.AspNetCore;

namespace Acme.SampleToDo.Web.Projects;

public class Update(IMediator mediator) : Endpoint<UpdateProjectRequest, UpdateProjectResponse>
{
  private readonly IMediator _mediator = mediator;

  public override void Configure()
  {
    Put(UpdateProjectRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateProjectRequest request,
    CancellationToken cancellationToken)
  {
    var result =
      await _mediator.Send(new UpdateProjectCommand(ProjectId.From(request.Id), ProjectName.From(request.Name!)));

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
