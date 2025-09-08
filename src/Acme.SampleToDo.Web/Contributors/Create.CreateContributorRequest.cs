using System.ComponentModel.DataAnnotations;

namespace Acme.SampleToDo.Web.Contributors;

public class CreateContributorRequest
{
  public const string Route = "/Contributors";

  [Required]
  public string Name { get; set; } = String.Empty;
}
