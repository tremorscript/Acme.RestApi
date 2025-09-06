using Acme.SampleToDo.Core.ContributorAggregate;

namespace Acme.Sample.ToDo.UseCases.Contributors.Commands.Update;

public record UpdateContributorCommand(int ContributorId, ContributorName NewName) : ICommand<Result<ContributorDTO>>;
