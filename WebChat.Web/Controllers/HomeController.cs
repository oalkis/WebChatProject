using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebChat.BLL;
using WebChat.Entities;
using WebChat.Web.Models;

namespace WebChat.Web.Controllers
{
    public class HomeController : Controller
    {

     

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View("Chat");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Chat()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Name = HttpContext.Session.GetString("username");
            ViewBag.UserId = HttpContext.Session.GetInt32("userId");
            return View();
        }
    }
}
