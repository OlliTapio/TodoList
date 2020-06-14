using System;

namespace TodoListProject.Requests
{
    public class RemoveItemRequest
    {
        public string GroupName { get; set; }

        public Guid ListId { get; set; }

        public Guid ItemId { get; set; }
    }
}