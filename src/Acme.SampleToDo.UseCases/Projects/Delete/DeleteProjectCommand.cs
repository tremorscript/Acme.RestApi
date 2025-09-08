using Acme.SampleToDo.Core.ProjectAggregate;

namespace Acme.SampleToDo.UseCases.Projects.Delete;

public record DeleteProjectCommand(ProjectId ProjectId) : ICommand<Result>;
