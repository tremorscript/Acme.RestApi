using Acme.SampleToDo.UseCases.Projects;
using Acme.SampleToDo.UseCases.Projects.ListIncompleteItems;

namespace Acme.SampleToDo.Infrastructure.Data.Queries;

public class FakeListIncompleteItemsQueryService : IListIncompleteItemsQueryService
{
  public async Task<IEnumerable<ToDoItemDTO>> ListAsync(int projectId)
  {
    var testItem = new ToDoItemDTO(1000, "test", "test description", false, null);
    return await Task.FromResult(new List<ToDoItemDTO> { testItem });
  }
}
