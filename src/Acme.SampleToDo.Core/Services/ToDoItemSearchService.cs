using Acme.SampleToDo.Core.Interfaces;
using Acme.SampleToDo.Core.ProjectAggregate;
using Acme.SampleToDo.Core.ProjectAggregate.Specifications;

namespace Acme.SampleToDo.Core.Services;

public class ToDoItemSearchService : IToDoItemSearchService
{
  public ToDoItemSearchService(IRepository<Project> repository)
  {
    _repository = repository;
  }

  private readonly IRepository<Project> _repository;
  
  public Task<Result<ToDoItem>> GetNextIncompleteItemAsync(ProjectId projectId)
  {
    throw new NotImplementedException();
  }

  public async Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(ProjectId projectId, string searchString)
  {
    if (String.IsNullOrEmpty(searchString))
    {
      var errors = new List<ValidationError>()
      {
        new() { Identifier = nameof(searchString), ErrorMessage = $"{nameof(searchString)} is required." }
      };
      
      return Result<List<ToDoItem>>.Invalid(errors);
    }
    
    var projectSpec = new ProjectByIdWithItemsSpec(projectId);
    var project = await _repository.FirstOrDefaultAsync(projectSpec);

    if (project == null)
    {
      return Result<List<ToDoItem>>.NotFound();
    }

    var incompleteSpec = new IncompleteItemsSearchSpec(searchString);
    try
    {
      var items = incompleteSpec.Evaluate(project.Items).ToList();

      return new Result<List<ToDoItem>>(items);
    }
    catch (Exception ex)
    {
      // TODO: Log details here
      return Result<List<ToDoItem>>.Error( ex.Message );
    }
  }
}
