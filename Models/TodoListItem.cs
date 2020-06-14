using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListProject.Models
{
    public class TodoListItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
        public string Color { get; set; }
    }
}
