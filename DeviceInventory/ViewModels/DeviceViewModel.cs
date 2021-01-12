using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceInventory.ViewModels
{
    public class DeviceViewModel
    {
        public int Id { get; set; }
      
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }

        public int ProfileId { get; set; }

        public string SerialNumber { get; set; }

        public int DeviceTypeId { get; set; }
        public string DeviceTypeName { get; set; }
       
        public int DeviceModelId { get; set; }
        public string DeviceModelName { get; set; }
      
        public int DeviceColorId { get; set; }
        public string DeviceColorName { get; set; }
      
        public int PropertyTypeId { get; set; }
        public string PropertyTypeName { get; set; }
  
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
