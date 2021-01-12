using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceInventory.ViewModels
{
    public class VisitorViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public TimeSpan ExpectedTime { get; set; }
        public DateTime Date { get; set; }
        public string DateString { get; set; }
        public int HostId { get; set; }
        public string UserID { get; set; }
        public string HostName { get; set; }
        public string HostEmail { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public bool CheckedIn { get; set; }
        public bool CheckedOut { get; set; }
        public bool PreScheduled { get; set; }
    }

    public class UpdateStatusViewModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }


}
