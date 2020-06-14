using TodoListProject.Database;
using TodoListProject.Models;

namespace TodoListProject.Mappers
{
    public static class TodoListItemMapper
    {
        public static TodoListItem ToDatabaseObject(this TodoListItemDto dto)
        {
            return new TodoListItem()
            {
                Done = dto.Done,
                Color = dto.Color,
                Name = dto.Name,
                Id = dto.Id
            };
        }

        public static TodoListItemDto ToDto(this TodoListItem dbObject)
        {
            return new TodoListItemDto()
            {
                Done = dbObject.Done,
                Color = dbObject.Color,
                Name = dbObject.Name,
                Id = dbObject.Id
            };
        }
    }
}