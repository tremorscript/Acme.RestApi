using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Acme.SampleToDo.Web.Projects;

public class MarkItemCompleteRequest
{
  public const string Route = "/Projects/{ProjectId:int}/ToDoItems/{ToDoItemId:int}";

  [Required] [FromRoute] public int ProjectId { get; set; } = 0;

  [Required] [FromRoute] public int ToDoItemId { get; set; } = 0;

  public static string BuildRoute(int projectId, int toDoItemId)
  {
    return Route.Replace("{ProjectId:int}", projectId.ToString())
      .Replace("{ToDoItemId:int}", toDoItemId.ToString());
  }
}
