using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DeviceInventory.Models;
using DeviceInventory.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DeviceInventory.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IProfileRepository _profile;

        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration, IProfileRepository profile)
        {
            _userManager = userManager;
            _configuration = configuration;
            _profile = profile;
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> InsertUser([FromForm] ProfileViewModel model)
        {
           




            //proces email
            var username = model.Email.Split("@")[0];

            if (_userManager.FindByNameAsync(username).Result == null)
            {
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = username,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                try
                {
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, model.RoleName);
                        // save to profile db
                        model.UserId = user.Id;
                        if (model.File != null || model.File.Length > 0)
                        {


                            // process file
                            string filename = "";
                            IFormFile file;
                            file = model.File;
                            model.ProfilePicture = filename;
                            filename = Guid.NewGuid() + file.FileName.Replace(" ", "_");
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\profile", filename);
                            var stream = new FileStream(path, FileMode.Create);
                            await file.CopyToAsync(stream);

                        }
                        try
                        {
                          
                               await _profile.SaveAsync(model);


                            return Ok(new ResoponseMessageViewModel { Status = 1, Message = "Successfully saved profile" });

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            return Ok(new ResoponseMessageViewModel { Status = 0, Message = "Cannot save profile" });

                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                return Ok(new { Username = model.Email });
            }
            else
            {
                return Ok(new { massage = "Duplicate User " });
            }



        }
        
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {

                var claim = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
                };
                var signinKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));
                int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Site"],
                    audience: _configuration["Jwt:Site"],
                    expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                    signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)


                    );
                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                        user = user.Id,

                    });

            }
            return Unauthorized();

        }
    }
}