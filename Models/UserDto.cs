using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListProject.Models
{
    public class UserDto
    {
        public string Name { get; set; }

        public List<TodoListDto> Lists { get; set; }
    }
}
