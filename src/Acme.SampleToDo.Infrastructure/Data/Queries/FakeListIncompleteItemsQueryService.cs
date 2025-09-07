﻿using Acme.Sample.ToDo.UseCases.Projects;
using Acme.Sample.ToDo.UseCases.Projects.ListIncompleteItems;

namespace Acme.SampleToDo.Infrastructure.Data.Queries;

public class FakeListIncompleteItemsQueryService : IListIncompleteItemsQueryService
{
  public async Task<IEnumerable<ToDoItemDTO>> ListAsync(int projectId)
  {
    var testItem = new ToDoItemDTO(Id: 1000, Title: "test", Description: "test description", IsComplete: false, null);
    return await Task.FromResult(new List<ToDoItemDTO>() { testItem});
  }
}
