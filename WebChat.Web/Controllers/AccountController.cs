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
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {

            if (HttpContext.Session.GetString("username") != null)
            {
                return RedirectToAction("Chat", "Home");
            }
            return View();
        }
        [HttpPost]

        public IActionResult Register(RegisterViewModel registerViewModel)
        {

            if (ModelState.IsValid)
            {

                User user = new User
                {
                    Email = registerViewModel.Email,
                    Username = registerViewModel.Username,
                    Password = Crypto.HashPassword(registerViewModel.Password),

                };
                _userService.Add(user);
            }
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("username")!=null)
            {
                return RedirectToAction("Chat", "Home");
            }
            return View();
        }
        [HttpPost]

        public IActionResult Login(LoginViewModel loginViewModel)
        {



            //var md5pass = Crypto.HashPassword(loginViewModel.Password);
            
          
            var user = _userService.GetUserByEmail(loginViewModel.Email);
            Crypto.VerifyHashedPassword(user.Password, loginViewModel.Password);
            if (Crypto.VerifyHashedPassword(user.Password, loginViewModel.Password))
            {
                HttpContext.Session.SetInt32("userId", user.UserId);
                HttpContext.Session.SetString("username", user.Username);
                return RedirectToAction("Chat", "Home");
            }
            else
            {
                ViewBag.Uyari = "Kullanıcı adını veya şifreyi hatalı girdiniz.";
                return View();
            }



        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                HttpContext.Session.Remove("username");
               
            }
          return RedirectToAction("Login");
        }
    }
}