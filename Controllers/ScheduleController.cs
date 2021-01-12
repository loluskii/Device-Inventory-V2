using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceInventory.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeviceInventory.Controllers
{
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Schedule",
                Subtitle="Index",
                Description = "Schedule visit Page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
        public IActionResult Create()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Schedule",
                Subtitle = "Create",
                Description = "Schedule visit Page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
    }
}