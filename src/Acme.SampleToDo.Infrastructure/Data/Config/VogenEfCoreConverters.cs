using Acme.SampleToDo.Core.ContributorAggregate;
using Acme.SampleToDo.Core.ProjectAggregate;
using Vogen;

namespace Acme.SampleToDo.Infrastructure.Data.Config;

[EfCoreConverter<ToDoItemId>]
[EfCoreConverter<ContributorName>]
[EfCoreConverter<ProjectName>]
[EfCoreConverter<ProjectId>]
internal partial class VogenEfCoreConverters;
