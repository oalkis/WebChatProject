using System;
using System.Collections.Generic;
using System.Text;
using WebChat.Entities;

namespace WebChat.DAL
{
   public class EfChatDal : EfEntityRepositoryBase<Chat, DatabaseContext>, IChatDal
    {
    }
}
