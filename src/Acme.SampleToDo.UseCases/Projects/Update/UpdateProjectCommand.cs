using Acme.SampleToDo.Core.ProjectAggregate;

namespace Acme.SampleToDo.UseCases.Projects.Update;

public record UpdateProjectCommand(ProjectId ProjectId, ProjectName NewName) : ICommand<Result<ProjectDTO>>;
