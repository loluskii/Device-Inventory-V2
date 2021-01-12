using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DeviceInventory.Models;
using DeviceInventory.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeviceInventory.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profile;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public ProfileController(IProfileRepository profile, RoleManager<ApplicationRole> roleManager)
        {
            _profile = profile;
            _roleManager = roleManager;
        }
        //api/profile/roles
        [Route("roles")]
        [HttpGet]
        public async Task<IActionResult> GetUserRoles()
        {
            var result = await _roleManager.Roles.Select(r => new RoleViewModel { Id = r.Id, Name = r.Name, NormalizedName = r.NormalizedName }).ToListAsync();
            return Ok(result);
        }
        //api/profile
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _profile.FindAllAsync();
            return Ok(result);
        }
      
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var result = await _profile.FindByIdAsync(Id);
            return Ok(result);
        }

        public  async Task<IActionResult> PostAsync([FromForm]ProfileViewModel model)
        {
            string filename = "";
            IFormFile file = model.File;
            if (file != null && file.Length > 0)
            {
                filename = file.FileName.Replace(" ", "_") + Guid.NewGuid();
            }
            else
            {
                filename = "default_profile.png";
            }
                try
                {
                    model.ProfilePicture = filename;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\profile", filename);
                    var stream = new FileStream(path, FileMode.Create);
                    try
                    {
                        await file.CopyToAsync(stream);
                        await _profile.SaveAsync(model);
                    return Ok(new ResoponseMessageViewModel { Status = 1, Message = "Successfully saved profile" });

                    }
                    catch (Exception ex)
                    {
                    Console.WriteLine(ex);
                        return Ok(new ResoponseMessageViewModel { Status = 0, Message = "Cannot save profile" });

                    }
                }catch(Exception ex)
                {

                    Console.WriteLine(ex);
                return Ok();
                }
           
        }
    }
}