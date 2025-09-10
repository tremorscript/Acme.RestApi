using Acme.SampleToDo.Core.Interfaces;
using Acme.SampleToDo.Core.ProjectAggregate;
using Acme.SampleToDo.Core.ProjectAggregate.Events;
using Acme.SampleToDo.Core.ProjectAggregate.Handlers;

namespace Acme.SampleToDo.UnitTests.Core.Handlers;

public class ItemCompletedEmailNotificationHandlerHandle
{
  private readonly IEmailSender _emailSender = Substitute.For<IEmailSender>();
  private readonly ItemCompletedEmailNotificationHandler _handler;

  public ItemCompletedEmailNotificationHandlerHandle()
  {
    _handler = new ItemCompletedEmailNotificationHandler(_emailSender);
  }

  [Fact]
  public async Task ThrowsExceptionGivenNullEventArgument()
  {
#nullable disable
    Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
#nullable enable
  }

  [Fact]
  public async Task SendsEmailGivenEventInstance()
  {
    await _handler.Handle(new ToDoItemCompletedEvent(new ToDoItem()), CancellationToken.None);

    await _emailSender.Received()
      .SendEmailAsync(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
  }
}
