using System;
using System.Collections.Generic;
using System.Text;
using WebChat.DAL;
using WebChat.Entities;

namespace WebChat.BLL
{
    public class UserManager : IUserService

    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(int userId)
        {
            var user = _userDal.Get(x => x.UserId == userId);
            _userDal.Delete(user);
        }

        public List<User> GetAll()
        {
            return _userDal.GetList();
        }

        public User GetByID(int userId)
        {
            return _userDal.Get(x => x.UserId == userId);
        }

        public User GetUserByEmail(string email)
        {
            return _userDal.Get(x => x.Email == email);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
