using System;
using System.Collections.Generic;

namespace CallCenter.Core.Models
{
    public partial class Buyers
    {
        public Buyers()
        {
            CallHistories = new HashSet<CallHistories>();
            SoldDevices = new HashSet<SoldDevices>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public ICollection<CallHistories> CallHistories { get; set; }
        public ICollection<SoldDevices> SoldDevices { get; set; }
    }
}
