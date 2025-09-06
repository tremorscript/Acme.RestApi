﻿using Acme.SampleToDo.Core.ProjectAggregate;

namespace Acme.Sample.ToDo.UseCases.Projects.MarkToDoItemComplete;

/// <summary>
/// Create a new Project.
/// </summary>
/// <param name="Name"></param>
public record MarkToDoItemCompleteCommand(ProjectId ProjectId, int ToDoItemId) : Ardalis.SharedKernel.ICommand<Result>;
