namespace Acme.SampleToDo.UseCases.Projects.ListIncompleteItems;

public record ListIncompleteItemsByProjectQuery(int ProjectId) : IQuery<Result<IEnumerable<ToDoItemDTO>>>;
