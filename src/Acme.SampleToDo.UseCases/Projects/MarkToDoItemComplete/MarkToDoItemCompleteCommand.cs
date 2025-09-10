using Acme.SampleToDo.Core.ProjectAggregate;

namespace Acme.SampleToDo.UseCases.Projects.MarkToDoItemComplete;

/// <summary>
///   Create a new Project
/// </summary>
/// <param name="ProjectId"></param>
/// <param name="ToDoItemId"></param>
public record MarkToDoItemCompleteCommand(ProjectId ProjectId, int ToDoItemId) : ICommand<Result>;
