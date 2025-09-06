using Acme.SampleToDo.Core.ContributorAggregate.Events;

namespace Acme.SampleToDo.Core.ContributorAggregate;

public class Contributor : EntityBase, IAggregateRoot
{
  public Contributor(ContributorName name)
  {
    Name = name;
  }

  public ContributorName Name { get; private set; }

  public Contributor UpdateName(ContributorName newName)
  {
    if (Name.Equals(newName))
    {
      return this;
    }

    Name = newName;
    RegisterDomainEvent(new ContributorNameUpdatedEvent(this));
    return this;
  }
}
