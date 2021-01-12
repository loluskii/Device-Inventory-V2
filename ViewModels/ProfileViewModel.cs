using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceInventory.ViewModels
{
    public class ProfileViewModel
    {

        public int Id { get; set; }
        public string EmployeeId { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public int SubsidiaryId { get; set; }
        public string SubsidiaryName { get; set; }
        public int EmployeeTypeId { get; set; }
        public string EmployeeTypeName { get; set; }
        public IFormFile File { get; set; }
        public string ProfilePicture { get; set; }
        public char Gender { get; set; }
        public bool isActive { get; set; }

    }
}
