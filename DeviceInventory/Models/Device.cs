using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceInventory.Models
{
    public class Device
    {
        public int Id { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        public int ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public int DeviceTypeId { get; set; }
        public virtual DeviceType DeviceType { get; set; }
        public int DeviceModelId { get; set; }
        public virtual DeviceModel DeviceModel { get; set; }
        public int DeviceColorId { get; set; }
        public virtual DeviceColor DeviceColor { get; set; }
        public int PropertyTypeId { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }




    }
}
