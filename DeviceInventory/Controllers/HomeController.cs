using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceInventory.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeviceInventory.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Login",
                Description = "Login Page",
                Active = "active",
                Area = "home"

            };
            return View(PageData);
        }
        public IActionResult Register()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Register",
                Description = "Retister",
                Active = "active",
                Area = "home"

            };
            return View(PageData);
        }
    }
}