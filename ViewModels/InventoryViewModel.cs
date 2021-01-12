using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceInventory.ViewModels
{
    public class InventoryViewModel
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public string DevicePropertyType { get; set; }
        public string MovementType { get; set; }   //Chceked in or out or exception
        public string ExceptionInfo { get; set; }
        public TimeSpan CheckedTime { get; set; }
        public DateTime CheckedDate { get; set; }
    }
}
