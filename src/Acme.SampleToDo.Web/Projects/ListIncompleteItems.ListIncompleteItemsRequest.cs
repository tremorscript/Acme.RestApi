using Microsoft.AspNetCore.Mvc;

namespace Acme.SampleToDo.Web.Projects;

public class ListIncompleteItemsRequest
{
  public const string Route = "/Projects/{ProjectId}/IncompleteItems";


  [FromRoute] public int ProjectId { get; set; }

  public static string BuildRoute(int projectId)
  {
    return Route.Replace("{ProjectId:int}", projectId.ToString());
  }
  //[FromQuery]
  //public string? SearchString { get; set; }
}
