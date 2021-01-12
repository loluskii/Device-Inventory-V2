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
    public class DevicePropertyTypeController : ControllerBase
    {
        private readonly IDevicePropertyTypeRepository _devicePropertyType;

        public DevicePropertyTypeController(IDevicePropertyTypeRepository devicePropertyType)
        {
            _devicePropertyType = devicePropertyType;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _devicePropertyType.FindAllAsync();
            return Ok(result);
        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var result = await _devicePropertyType.FindByIdAsync(Id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]DevicePropertyTypeViewModel model)
        {
            if (model.Name != null)
            {
                try
                {
                    await _devicePropertyType.SaveAsync(model);
                    return Ok(new ResoponseMessageViewModel { Status = 1, Message = "successfully saved device Property Type" });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return Ok(new ResoponseMessageViewModel { Status = 0, Message = "Cannot save device Property Type" });

                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}