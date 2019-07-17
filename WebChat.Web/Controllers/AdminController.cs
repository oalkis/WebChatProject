using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebChat.BLL;
using WebChat.Entities;
using WebChat.Web.Models;

namespace WebChat.Web.Controllers
{
    public class AdminController : Controller
    {
        private IUserService _userService;
        private IChatService _chatService;

        public AdminController(IUserService userService, IChatService chatService)
        {
            _userService = userService;
            _chatService = chatService;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public IActionResult AddUser()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();

        }
        [HttpPost]
        public IActionResult AddUser(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {

                User user = new User
                {
                    Email = addUserViewModel.Email,
                    Username = addUserViewModel.Username,
                    Password = Crypto.HashPassword(addUserViewModel.Password),

                };
                _userService.Add(user);
            }
            return RedirectToAction("Users");

        }
        public IActionResult UpdateUser(int id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var user = _userService.GetByID(id);
            var model = new UpdateUserViewModel
            {
                UserId = user.UserId,
                Email = user.Email,
                Username = user.Username
            };

            return View(model);
        }
        [HttpPost]

        public IActionResult UpdateUser(UpdateUserViewModel updateUserViewModel)
        {
            var user = _userService.GetByID(updateUserViewModel.UserId);
            user.Email = updateUserViewModel.Email;
            user.Username = updateUserViewModel.Username;

            if (ModelState.IsValid)
            {

                _userService.Update(user);
            }
            return RedirectToAction("Users");
        }
        public ActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Users");
        }
        public ActionResult Users()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var users = _userService.GetAll();
            return View(users);
        }
        public ActionResult Chats()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var model = new ChatListViewModel
            {
                Chats = _chatService.GetAll(),
                Users = _userService.GetAll()
            };

            return View(model);
        }
        public ActionResult DeleteMessage(int id)
        {
            _chatService.Delete(id);
            return RedirectToAction("Chats");
        }
        public IActionResult UpdateMessage(int id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var model = new UpdateChatViewModel
            {
                chat = _chatService.GetByID(id),
                Users = _userService.GetAll()
            };

            return View(model);
        }
        [HttpPost]

        public IActionResult UpdateMessage( UpdateChatViewModel updateChatViewModel)
        {



            if (ModelState.IsValid)
            {

                _chatService.Update(updateChatViewModel.chat);
            }
            return RedirectToAction("Chats");
        }
    }
}