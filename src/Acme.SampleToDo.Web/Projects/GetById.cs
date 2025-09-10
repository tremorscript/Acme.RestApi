using Acme.SampleToDo.Core.ProjectAggregate;
using Acme.SampleToDo.UseCases.Projects.GetWithAllItems;

namespace Acme.SampleToDo.Web.Projects;

public class GetById(IMediator mediator) : Endpoint<GetProjectByIdRequest, GetProjectByIdResponse>
{
  private readonly IMediator _mediator = mediator;

  public override void Configure()
  {
    Get(GetProjectByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetProjectByIdRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetProjectWithAllItemsQuery(ProjectId.From(request.ProjectId));

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new GetProjectByIdResponse(result.Value.Id,
        result.Value.Name,
        result.Value.Items
          .Select(item => new ToDoItemRecord(
            item.Id,
            item.Title,
            item.Description,
            item.IsComplete,
            item.ContributorId
          ))
          .ToList()
      );
    }
  }
}
