using System;
using System.Collections.Generic;
using System.Text;
using WebChat.Entities;

namespace WebChat.BLL
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetByID(int userId);
        User GetUserByEmail(string email);
        void Add(User user);
        void Update(User user);
        void Delete(int userId);


    }
}
