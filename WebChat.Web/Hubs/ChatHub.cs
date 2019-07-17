using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WebChat.BLL;
using WebChat.Entities;

namespace WebChat.Web.Hubs
{
    public class ChatHub:Hub
    {
        private IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(string user, string message,int userId)
            
        {
            var chat = new Chat
            {
                CreateDate = DateTime.Now,
                Messages = message,
                UserId = userId
            };
            _chatService.Add(chat);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

       
    }
}
