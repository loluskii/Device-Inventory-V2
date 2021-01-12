using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceInventory.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeviceInventory.Controllers
{
    public class VisitorController : Controller
    {
        public IActionResult Index()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Visitor Management",
                Subtitle = "Index",
                Description = "Visitor Management Page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }

        public IActionResult VisitorList()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Visitor Management",
                Subtitle = "VisitorList",
                Description = "Visitor Management Page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
        public IActionResult Report()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Visitor Management",
                Subtitle = "Report",
                Description = "Visitor Management Page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }

    }
}