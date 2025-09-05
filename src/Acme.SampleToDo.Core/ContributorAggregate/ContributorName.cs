using Vogen;

namespace Acme.SampleToDo.Core.ContributorAggregate;

[ValueObject<string>(Conversions.SystemTextJson | Conversions.XmlSerializable)]
public partial struct ContributorName
{
  private static Validation Validate(in string name) =>
    String.IsNullOrEmpty(name) ? Validation.Invalid("Name cannot be empty") : Validation.Ok;
}
