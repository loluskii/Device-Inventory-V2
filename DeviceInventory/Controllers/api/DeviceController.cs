using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceInventory.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeviceInventory.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {

        private readonly IDeviceRepository _device;

        public DeviceController(IDeviceRepository device)
        {
            _device = device;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _device.FindAllAsync();
            return Ok(result);
        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var result = await _device.FindByIdAsync(Id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]DeviceViewModel model)
        {
            if (model.EmployeeId != null)
            {
                try
                {
                    await _device.SaveAsync(model);
                    return Ok(new ResoponseMessageViewModel { Status = 1, Message = "successfully saved device" });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return Ok(new ResoponseMessageViewModel { Status = 0, Message = "Cannot save device" });

                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}