using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListProject.Database;
using TodoListProject.Mappers;
using TodoListProject.Models;

namespace TodoListProject.Services
{
    public interface ITodoListService
    {
        Task<TodoListItemDto> AddOrReplaceItem(Guid listId, TodoListItemDto item);
        Task<TodoListDto> CreateList(string name);
        TodoListDto GetList(Guid listId);
        Task<Guid> RemoveItem(Guid listId, Guid itemId);
    }

    public class TodoListService : ITodoListService
    {
        public readonly TodoListContext Context;

        public TodoListService(TodoListContext context)
        {
            Context = context;
        }

        public async Task<TodoListItemDto> AddOrReplaceItem(Guid listId, TodoListItemDto item)
        {
            var listToEdit = Context.TodoLists.FirstOrDefault(x => x.Id == listId);

            var itemToReplace = listToEdit.Items.FirstOrDefault(x => x.Id == item.Id);

            var dbItem = item.ToDatabaseObject();

            if (itemToReplace == null)
            {
                listToEdit.Items.Add(dbItem);
            }
            else
            {
                listToEdit.Items.Remove(itemToReplace);
                listToEdit.Items.Add(dbItem);
            }

            await Context.SaveChangesAsync();

            return dbItem.ToDto();
        }

        public async Task<Guid> RemoveItem(Guid listId, Guid itemId)
        {
            var listToEdit = Context.TodoLists.FirstOrDefault(x => x.Id == listId);

            var itemToRemove = listToEdit.Items.FirstOrDefault(x => x.Id == itemId);

            if (itemToRemove != null)
            {
                listToEdit.Items.Remove(itemToRemove);
                await Context.SaveChangesAsync();
            }

            return itemId;
        }

        public TodoListDto GetList(Guid listId)
        {
            var list = Context.TodoLists.FirstOrDefault(x => x.Id == listId);
            return list.ToDto();
        }

        public async Task<TodoListDto> CreateList(string name)
        {
            var list = new TodoList() { Name = name };

            await Context.TodoLists.AddAsync(list);
            await Context.SaveChangesAsync();

            return list.ToDto();
        }
    }
}
