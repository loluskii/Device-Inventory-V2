using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceInventory.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeviceInventory.Controllers
{
    public class DeviceController : Controller
    {
        public IActionResult Index()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Device Management",
                Subtitle = "Index",
                Description = "Device Management page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
        public IActionResult Create()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Device Management",
                Subtitle ="Create",
                Description = "Device Management page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
        public IActionResult DeviceType()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Device Management",
                Subtitle = "DeviceType",
                Description = "Device Management page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
        public IActionResult DeviceModel()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Device Management",
                Subtitle = "DeviceModel",
                Description = "Device Management page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
        public IActionResult Color()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Device Management",
                Subtitle = "Color",
                Description = "Device Management page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
        public IActionResult PropertyType()
        {
            PageViewModel PageData = new PageViewModel()
            {
                Title = "Device Management",
                Subtitle = "PropertyType",
                Description = "Device Management page",
                Active = "active",
                Area = "dashboard"

            };
            return View(PageData);
        }
    }
}