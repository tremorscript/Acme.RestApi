using Acme.SampleToDo.Core.ProjectAggregate;

namespace Acme.Sample.ToDo.UseCases.Projects.AddToDoItem;

/// <summary>
/// Creates a new <see cref="ToDoItem"/> and adds it to a Project
/// </summary>
/// <param name="ProjectId"></param>
/// <param name="ContributorId"></param>
/// <param name="Title"></param>
/// <param name="Description"></param>
public record AddToDoItemCommand(
  ProjectId ProjectId,
  int? ContributorId,
  string Title,
  string Description) : ICommand<Result<ToDoItemId>>;
