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
    public class DeviceModelController : ControllerBase
    {
        private readonly IDeviceModelRepository _deviceModel;

        public DeviceModelController(IDeviceModelRepository deviceModel)
        {
            _deviceModel = deviceModel;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _deviceModel.FindAllAsync();
            return Ok(result);
        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var result = await _deviceModel.FindByIdAsync(Id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]DeviceModelViewModel model)
        {
            if (model.Name != null)
            {
                try
                {
                    await _deviceModel.SaveAsync(model);
                    return Ok(new ResoponseMessageViewModel { Status = 1, Message = "successfully saved device Model" });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return Ok(new ResoponseMessageViewModel { Status = 0, Message = "Cannot save device model" });

                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}