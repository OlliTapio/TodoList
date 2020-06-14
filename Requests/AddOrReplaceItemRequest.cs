using System;
using TodoListProject.Models;

namespace TodoListProject.Responses
{
    public class AddOrReplaceItemRequest
    {
        public string GroupName { get; set; }

        public Guid ListId { get; set; }

        public TodoListItemDto TodoListItem { get; set; }
    }
}