using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using TodoListProject.Requests;
using TodoListProject.Responses;
using TodoListProject.Services;

namespace TodoListProject.Hubs
{
    public class TodoListHub : Hub
    {
        private readonly ITodoListService _todoListService;

        public TodoListHub(ITodoListService todoList)
        {
            _todoListService = todoList;
        }

        public async Task CreateList(GroupRequest request)
        {
            var list = await _todoListService.CreateList(request.Name);

            await Groups.AddToGroupAsync(Context.ConnectionId, list.Id.ToString());

            await Clients.Caller.SendAsync("Joined", new TodoListResponse() { TodoList = list });
        }

        public async Task JoinList(JoinRequest request)
        {
            var list = _todoListService.GetList(request.ListId);

            await Groups.AddToGroupAsync(Context.ConnectionId, list.Name);

            await Clients.Group(request.ListId.ToString()).SendAsync("Send", $"{Context.ConnectionId} has joined the group {list.Name}.");

            await Clients.Caller.SendAsync("Joined", new TodoListResponse() { TodoList = list });
        }

        public async Task AddOrReplaceItem(AddOrReplaceItemRequest request)
        {
            var item = await _todoListService.AddOrReplaceItem(request.ListId, request.TodoListItem);

            await Clients.Group(request.ListId.ToString()).SendAsync("AddOrReplace", new AddOrReplaceItemResponse() { TodoListItem = item });
        }

        public async Task RemoveItem(RemoveItemRequest request)
        {
            var removed = await _todoListService.RemoveItem(request.ListId, request.ItemId);

            await Clients.Group(request.ListId.ToString()).SendAsync("Remove", new RemoveItemResponse() { Removed = removed });
        }

        public async Task LeaveList(JoinRequest request)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, request.ListId.ToString());

            await Clients.Group(request.ListId.ToString()).SendAsync("Send", $"{Context.ConnectionId} has left the group.");
        }
    }
}