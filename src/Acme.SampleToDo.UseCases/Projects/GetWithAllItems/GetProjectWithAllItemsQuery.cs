using Acme.SampleToDo.Core.ProjectAggregate;

namespace Acme.SampleToDo.UseCases.Projects.GetWithAllItems;

public record GetProjectWithAllItemsQuery(ProjectId ProjectId) : IQuery<Result<ProjectWithAllItemsDTO>>;
