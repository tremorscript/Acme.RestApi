namespace Acme.SampleToDo.Core.ProjectAggregate.Events;

public class ContributorAddedToItemEvent : DomainEventBase
{
  public ContributorAddedToItemEvent(ToDoItem item, int contributorId)
  {
    Item = item;
    ContributorId = contributorId;
  }

  public int ContributorId { get; set; }

  public ToDoItem Item { get; set; }
}
