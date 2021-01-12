using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceInventory.Models
{
    public class Profile
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public int SubsidiaryId { get; set; }
        public virtual Subsidiary Subsidiary { get; set; }

        public int EmployeeTypeId { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
        public string ProfilePicture { get; set; }
        public string Pin { get; set; }
        public char Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
