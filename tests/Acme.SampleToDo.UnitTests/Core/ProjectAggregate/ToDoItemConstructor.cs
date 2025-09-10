using Acme.SampleToDo.Core.ProjectAggregate;

namespace Acme.SampleToDo.UnitTests.Core.ProjectAggregate;

public class ToDoItemConstructor
{
  [Fact]
  public void InitializesPriority()
  {
    var item = new ToDoItemBuilder()
      .WithDefaultValues()
      .Build();

    Assert.Equal(item.Priority, Priority.Backlog);
  }
}
