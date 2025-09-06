using Acme.SampleToDo.Core.ProjectAggregate;

namespace Acme.Sample.ToDo.UseCases.Projects.Delete;

public record DeleteProjectCommand(ProjectId ProjectId) : ICommand<Result>;
