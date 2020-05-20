using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace TodoList.Hubs
{
  public class ChatHub : Hub
  {
    public async Task NewMessage(long username, string message)
    {
      await Clients.All.SendAsync("messageReceived", username, message);
    }
  }
}