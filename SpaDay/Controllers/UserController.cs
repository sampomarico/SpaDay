using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("/user")]
        public IActionResult SubmitAddUserForm(User newUser, string verify)
        {
            if(newUser.Password == verify)
            {
                ViewBag.username = newUser.Username;
                ViewBag.email = newUser.Email;
                newUser.DateCreated = DateTime.Now;
                ViewBag.date = newUser.DateCreated;
                return View("Index");
            }
            else
            {
                ViewBag.error = "Passwords do not match";
                ViewBag.username = newUser.Username;
                ViewBag.email = newUser.Email;
                return View("Add");
            }
        }
    }
}
