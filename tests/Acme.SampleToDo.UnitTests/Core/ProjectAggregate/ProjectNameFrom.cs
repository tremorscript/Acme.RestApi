﻿using Acme.SampleToDo.Core.ProjectAggregate;
using Shouldly;
using Vogen;

namespace Acme.SampleToDo.UnitTests.Core.ProjectAggregate;

public class ProjectNameFrom
{
  [Theory]
  [InlineData("")]
  [InlineData(null!)]
  public void ThrowsGivenNullOrEmpty(string name)
  {
    Should.Throw<ValueObjectValidationException>(() => ProjectName.From(name));
  }

  [Fact]
  public void DoesNotThrowGivenValidData()
  {
    string validName = "valid name";
    var name = ProjectName.From(validName);
    name.Value.ShouldBe(validName);
  }
}
