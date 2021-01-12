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
    public class SubsidiaryController : ControllerBase
    {
        private readonly ISubsidiaryRepository _subsidiary;

        public SubsidiaryController(ISubsidiaryRepository subsidiary)
        {
            _subsidiary = subsidiary;

        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _subsidiary.FindAllAsync();
            return Ok(result);
        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var result = await _subsidiary.FindByIdAsync(Id);
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SubsidiaryViewModel model)
        {
            if(model.Name != null)
            {
                try
                {
                    await _subsidiary.SaveAsync(model);
                    return Ok(new ResoponseMessageViewModel { Status = 1, Message = "successfully saved subsidiary" });
                }catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    return Ok(new ResoponseMessageViewModel { Status = 0, Message = "Cannot save subsidiary" });

                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
