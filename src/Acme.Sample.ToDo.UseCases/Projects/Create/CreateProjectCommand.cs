using Acme.SampleToDo.Core.ProjectAggregate;

namespace Acme.Sample.ToDo.UseCases.Projects.Create;

public record CreateProjectCommand(string Name) : ICommand<Result<ProjectId>>;
