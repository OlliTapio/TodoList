﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListProject.Models;

namespace TodoListProject.Responses
{
    public class AddOrReplaceItemResponse
    {
        public TodoListItemDto TodoListItem { get; set; }
    }
}
