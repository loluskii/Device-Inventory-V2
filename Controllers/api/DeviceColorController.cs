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
    public class DeviceColorController : ControllerBase
    {
        private readonly IDeviceColorRepository _deviceColor;

        public DeviceColorController(IDeviceColorRepository deviceColor)
        {
            _deviceColor = deviceColor;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _deviceColor.FindAllAsync();
            return Ok(result);
        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var result = await _deviceColor.FindByIdAsync(Id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]DeviceColorViewModel model)
        {
            if (model.Name != null)
            {
                try
                {
                    await _deviceColor.SaveAsync(model);
                    return Ok(new ResoponseMessageViewModel { Status = 1, Message = "successfully saved device Color" });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return Ok(new ResoponseMessageViewModel { Status = 0, Message = "Cannot save device color" });

                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}