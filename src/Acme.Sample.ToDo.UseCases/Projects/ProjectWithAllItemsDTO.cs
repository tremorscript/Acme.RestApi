namespace Acme.Sample.ToDo.UseCases.Projects;

public record ProjectWithAllItemsDTO(int Id, string Name, List<ToDoItemDTO> Items, string Status);
