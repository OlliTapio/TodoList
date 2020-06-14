using System.Linq;
using TodoListProject.Database;
using TodoListProject.Models;

namespace TodoListProject.Mappers
{
    public static class TodoListMapper
    {
        public static TodoList ToDatabaseObject(this TodoListDto dto)
        {
            return new TodoList()
            {
                Items = dto.Items.Select(x => x.ToDatabaseObject()).ToList(),
                Name = dto.Name,
                Id = dto.Id
            };
        }

        public static TodoListDto ToDto(this TodoList dbObject)
        {
            return new TodoListDto()
            {
                Items = dbObject.Items.Select(x => x.ToDto()).ToList(),
                Name = dbObject.Name,
                Id = dbObject.Id
            };
        }
    }
}