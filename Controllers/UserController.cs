using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceInventory.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeviceInventory.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "User Management",
                Subtitle="Index",
                Description = "User Management page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
        public IActionResult Create()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "User Management",
                Subtitle = "Create",
                Description = "User Management page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
     
        public IActionResult ResetPin()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "User Management",
                Subtitle = "ResetPin",
                Description = "User Management page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
        public IActionResult Subsidiary()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "User Management",
                Subtitle = "Subsidiary",
                Description = "Manage Subsidiary page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
        public IActionResult EmployeeType()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "User Management",
                Subtitle = "EmployeeType",
                Description = "EmployeeType Management page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
    }
}