using Acme.SampleToDo.Core.ProjectAggregate;

namespace Acme.SampleToDo.UseCases.Projects.Create;

public record CreateProjectCommand(string Name) : ICommand<Result<ProjectId>>;
