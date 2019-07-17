using System;
using System.Collections.Generic;
using System.Text;
using WebChat.DAL;
using WebChat.Entities;

namespace WebChat.BLL
{
    public class ChatManager : IChatService
    {
        private IChatDal _chatDal;

        public ChatManager(IChatDal chatDal)
        {
            _chatDal = chatDal;
        }

        public void Add(Chat chat)
        {
            _chatDal.Add(chat);
        }

        public void Delete(int chatId)
        {
            var chat = _chatDal.Get(x => x.ChatId == chatId);
            _chatDal.Delete(chat);
        }

        public List<Chat> GetAll()
        {
            return _chatDal.GetList();
        }

        public Chat GetByID(int chatId)
        {
            return _chatDal.Get(c => c.ChatId == chatId);
        }

        public void Update(Chat chat)
        {
            _chatDal.Update(chat);
        }
    }
}
