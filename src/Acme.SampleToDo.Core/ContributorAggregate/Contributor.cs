﻿using Acme.SampleToDo.Core.ContributorAggregate.Events;

namespace Acme.SampleToDo.Core.ContributorAggregate;

public class Contributor : EntityBase, IAggregateRoot
{
  public ContributorName Name { get; private set; }

  public Contributor(ContributorName name)
  {
    Name = name;
  }

  public Contributor UpdateName(ContributorName newName)
  {
    if (Name.Equals(newName)) return this;
    Name = newName;
    this.RegisterDomainEvent(new ContributorNameUpdatedEvent(this));
    return this;
  }
}

