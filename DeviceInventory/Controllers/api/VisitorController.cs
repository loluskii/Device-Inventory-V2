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
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorRepository _visitor;
        private readonly IProfileRepository _profile;

        public VisitorController(IVisitorRepository visitor, IProfileRepository profile)
        {
            _visitor = visitor;
            _profile = profile;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _visitor.FindAllAsync();
            return Ok(result);
        }

        [Route("today")]
        [HttpGet]
        public async Task<IActionResult> GetTodayAsync()
        {
            var result = await _visitor.FindTodayAsync();
            return Ok(result);
        }

        [Route("status")]
        [HttpPut]
        public async Task<IActionResult> PutVisitorStatus([FromBody] UpdateStatusViewModel model)
        {
            if (model.Id != 0)
            {


                try
                {

                    await _visitor.UpdateVisitorStatusAsync(model);


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                }
            }
            return Ok(model.Id);
        
        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var result = await _visitor.FindByIdAsync(Id);
            return Ok(result);
        }

        [Route("host/{hostId}")]
        [HttpGet]
        public async Task<IActionResult> GetByHostIdAsync(string hostId)
        {
            var result = await _visitor.FindByHostIdAsync(hostId);
            return Ok(result);
        }
        [Route("status/{statusName}")]
        [HttpGet]
        public async Task<IActionResult> GetByStatusNameAsync(string statusName)
        {
            var result = await _visitor.FindByStatusNameAsync(statusName);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]VisitorViewModel model)
        {
            var user = await _profile.FindByUserIdAsync(model.UserID);
            model.HostId = user.Id;
            Console.WriteLine();
            Console.WriteLine(model.HostId);
            Console.WriteLine();
            if (model.PhoneNumber != null)
            {
            
                try
                {
                    await _visitor.SaveAsync(model);
                    return Ok(new ResoponseMessageViewModel { Status = 1, Message = "successfully saved Visitor" });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return Ok(new ResoponseMessageViewModel { Status = 0, Message = "Cannot save Visitor" });

                }
            }
            else
            {
                return BadRequest();
            }
        }


    }
}