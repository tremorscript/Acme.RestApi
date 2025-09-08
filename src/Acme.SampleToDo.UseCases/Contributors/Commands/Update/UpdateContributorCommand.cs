using Acme.SampleToDo.Core.ContributorAggregate;

namespace Acme.SampleToDo.UseCases.Contributors.Commands.Update;

public record UpdateContributorCommand(int ContributorId, ContributorName NewName) : ICommand<Result<ContributorDTO>>;
