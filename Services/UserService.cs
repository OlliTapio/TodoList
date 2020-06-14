using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListProject.Database;
using TodoListProject.Mappers;
using TodoListProject.Models;

namespace TodoListProject.Services
{
    public interface IUserService
    {
        Task CreateUser(string userName);
        Task<TodoListDto> JoinList(string userName, Guid listId);
    }

    public class UserService : IUserService
    {
        public readonly TodoListContext Context;

        public UserService(TodoListContext context)
        {
            Context = context;
        }

        public async Task CreateUser(string userName)
        {
            var user = new User { UserName = userName };

            Context.Users.Add(user);
            await Context.SaveChangesAsync();
        }

        public async Task<TodoListDto> JoinList(string userName, Guid listId)
        {
            var listToJoin = Context.TodoLists.FirstOrDefault(x => x.Id == listId);
            var user = Context.Users.FirstOrDefault(x => x.UserName == userName);

            if (listToJoin != null && user != null)
            {
                user.TodoLists.Add(listToJoin);
                await Context.SaveChangesAsync();
            }
            else
            {
                return null;
            }

            return listToJoin.ToDto();
        }


    }
}
