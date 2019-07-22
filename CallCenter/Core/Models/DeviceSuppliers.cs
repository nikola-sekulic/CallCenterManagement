using System;
using System.Collections.Generic;

namespace CallCenter.Core.Models
{
    public partial class DeviceSuppliers
    {
        public DeviceSuppliers()
        {
            SoldDevices = new HashSet<SoldDevices>();
        }

        public string CompamyName { get; set; }
        public string Address { get; set; }

        public ICollection<SoldDevices> SoldDevices { get; set; }
    }
}
