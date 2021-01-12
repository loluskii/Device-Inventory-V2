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
    public class DeviceTypeController : ControllerBase
    {
        private readonly IDeviceTypeRepository _deviceType;

        public DeviceTypeController(IDeviceTypeRepository deviceType)
        {
            _deviceType = deviceType;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _deviceType.FindAllAsync();
            return Ok(result);
        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var result = await _deviceType.FindByIdAsync(Id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]DeviceTypeViewModel model)
        {
            if (model.Name != null)
            {
                try
                {
                    await _deviceType.SaveAsync(model);
                    return Ok(new ResoponseMessageViewModel { Status = 1, Message = "successfully saved device type" });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return Ok(new ResoponseMessageViewModel { Status = 0, Message = "Cannot save device type" });

                }
            }
            else
            {
                return BadRequest();
            }
        }

    }
}