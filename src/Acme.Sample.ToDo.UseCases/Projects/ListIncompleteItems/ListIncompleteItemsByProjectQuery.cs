namespace Acme.Sample.ToDo.UseCases.Projects.ListIncompleteItems;

public record ListIncompleteItemsByProjectQuery(int ProjectId): IQuery<Result<IEnumerable<ToDoItemDTO>>>;
