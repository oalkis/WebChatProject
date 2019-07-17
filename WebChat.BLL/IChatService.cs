using System;
using System.Collections.Generic;
using System.Text;
using WebChat.Entities;

namespace WebChat.BLL
{
    public interface IChatService
    {
        List<Chat> GetAll();
        Chat GetByID(int chatId);
        void Add(Chat chat);
        void Update(Chat chat);
        void Delete(int chatId);


    }
}
