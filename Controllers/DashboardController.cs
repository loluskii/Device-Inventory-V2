using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceInventory.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeviceInventory.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Dashboard",
                Description = "Admin Area dashboard",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
    }
}