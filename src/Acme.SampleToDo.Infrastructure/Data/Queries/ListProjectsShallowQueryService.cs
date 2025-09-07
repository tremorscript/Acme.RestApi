using Acme.Sample.ToDo.UseCases.Projects;
using Acme.Sample.ToDo.UseCases.Projects.ListShallow;

namespace Acme.SampleToDo.Infrastructure.Data.Queries;

public class ListProjectsShallowQueryService(AppDbContext db) : 
  IListProjectsShallowQueryService
{
  private readonly AppDbContext _db = db;

  public async Task<IEnumerable<ProjectDTO>> ListAsync()
  {
    var result = await _db.Projects.FromSqlRaw("SELECT Id, Name FROM Projects") // don't fetch other big columns
      .Select(x => new ProjectDTO(x.Id.Value, x.Name.Value, x.Status.ToString()))
      .ToListAsync();

    return result;
  }
}
