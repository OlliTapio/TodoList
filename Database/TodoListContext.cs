using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace TodoListProject.Database
{
    public class TodoListContext : DbContext
    {
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoListItem> Items { get; set; }
        public DbSet<User> Users { get; set; }
    }

    public class TodoList
    {
        public Guid Id { get; set; }
        public List<TodoListItem> Items { get; set; }
        public string Name { get; set; }
    }

    public class TodoListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
        public string Color { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; }
        public List<TodoList> TodoLists { get; set; }
        public string UserName { get; set; }
    }
}