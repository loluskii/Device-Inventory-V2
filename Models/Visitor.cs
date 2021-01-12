using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceInventory.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public TimeSpan ExpectedTime { get; set; }
        public DateTime Date { get; set; }
        public Char Gender { get; set; }
        public int HostId { get; set; }
        [ForeignKey("HostId")]
        public virtual Profile Profile { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }

        public int DeviceId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
