using Acme.SampleToDo.Core.ContributorAggregate;

namespace Acme.Sample.ToDo.UseCases.Contributors.Commands.Create;

public record CreateContributorCommand(ContributorName Name) : ICommand<Result<int>>;
