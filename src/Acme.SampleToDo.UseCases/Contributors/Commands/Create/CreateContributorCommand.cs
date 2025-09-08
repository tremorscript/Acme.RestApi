using Acme.SampleToDo.Core.ContributorAggregate;

namespace Acme.SampleToDo.UseCases.Contributors.Commands.Create;

public record CreateContributorCommand(ContributorName Name) : ICommand<Result<int>>;
