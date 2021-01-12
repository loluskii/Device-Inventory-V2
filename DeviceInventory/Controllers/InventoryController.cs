using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceInventory.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeviceInventory.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Inventory",
                Subtitle = "Index",
                Description = "Device Inventory page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
        public IActionResult Weekly()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Inventory",
                Subtitle = "Weekly",
                Description = "Device Inventory page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
        public IActionResult Monthly()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Inventory",
                Subtitle = "Monthly",
                Description = "Device Inventory page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
    }
}