using Acme.SampleToDo.Core.ProjectAggregate.Events;

namespace Acme.SampleToDo.Core.ProjectAggregate;

public class Project : EntityBase<Project, ProjectId>, IAggregateRoot
{
  private readonly List<ToDoItem> _items = [];

  public Project(ProjectName name)
  {
    Name = name;
  }

  public ProjectName Name { get; private set; }
  public IEnumerable<ToDoItem> Items => _items.AsReadOnly();

  public ProjectStatus Status => _items.All(i => i.IsDone) ? ProjectStatus.Complete : ProjectStatus.InProgress;

  public Project AddItem(ToDoItem newItem)
  {
    Guard.Against.Null(newItem, nameof(newItem));
    _items.Add(newItem);

    var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
    RegisterDomainEvent(newItemAddedEvent);
    return this;
  }

  public Project UpdateName(ProjectName newName)
  {
    Name = newName;
    return this;
  }
}
