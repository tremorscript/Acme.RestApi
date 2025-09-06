using Acme.SampleToDo.Core.ProjectAggregate;

namespace Acme.Sample.ToDo.UseCases.Projects.Update;

public record UpdateProjectCommand(ProjectId ProjectId, ProjectName NewName) : ICommand<Result<ProjectDTO>>;
