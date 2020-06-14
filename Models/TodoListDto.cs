using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoListProject.Models
{
    public class TodoListDto
    {
        public Guid Id { get; set; }
        public List<TodoListItemDto> Items { get; set; } = new List<TodoListItemDto>();
        public string Name { get; set; }
    }
}