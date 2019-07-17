using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.Entities;

namespace WebChat.Web.Models
{
    public class ChatListViewModel
    {
        public List<Chat> Chats { get; internal set; }
        public List<User> Users { get; set; }
    }
}
