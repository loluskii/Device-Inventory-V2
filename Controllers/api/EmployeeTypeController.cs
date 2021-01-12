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
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeRepository _employeeType;

        public EmployeeTypeController(IEmployeeTypeRepository employeeType)
        {
            _employeeType = employeeType;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _employeeType.FindAllAsync();
            return Ok(result);
        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var result = await _employeeType.FindByIdAsync(Id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]EmployeeTypeViewModel model)
        {
            if (model.Name != null)
            {
                try
                {
                    await _employeeType.SaveAsync(model);
                    return Ok(new ResoponseMessageViewModel { Status = 1, Message = "successfully saved employee type" });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return Ok(new ResoponseMessageViewModel { Status = 0, Message = "Cannot save employee type" });

                }
            }
            else
            {
                return BadRequest();
            }
        }


    }
}