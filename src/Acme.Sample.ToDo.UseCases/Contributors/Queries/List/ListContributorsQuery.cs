namespace Acme.Sample.ToDo.UseCases.Contributors.Queries.List;

public record ListContributorsQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<ContributorDTO>>>;
