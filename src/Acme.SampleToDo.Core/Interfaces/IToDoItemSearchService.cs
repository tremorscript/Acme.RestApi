using Acme.SampleToDo.Core.ProjectAggregate;

namespace Acme.SampleToDo.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(ProjectId projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(ProjectId projectId, string searchString);
}
