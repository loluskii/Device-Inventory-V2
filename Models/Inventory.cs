using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceInventory.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public virtual Device Device { get; set; }
        public string MovementType { get; set; }   //Chceked in or out or exception
        public string ExceptionInfo { get; set; }
        public TimeSpan CheckedTime { get; set; }
        public DateTime CheckedDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }


    }
}
