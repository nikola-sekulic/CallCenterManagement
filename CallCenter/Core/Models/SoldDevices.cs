using System;
using System.Collections.Generic;

namespace CallCenter.Core.Models
{
    public partial class SoldDevices
    {
        public SoldDevices()
        {
            Reclamations = new HashSet<Reclamations>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime WarrantyStartDate { get; set; }
        public DateTime WarrantyEndDate { get; set; }
        public int BuyerId { get; set; }
        public decimal Price { get; set; }
        public string DeviceSupplierCompamyName { get; set; }

        public Buyers Buyer { get; set; }
        public DeviceSuppliers DeviceSupplierCompamyNameNavigation { get; set; }
        public ICollection<Reclamations> Reclamations { get; set; }

        public bool ExpiredWarranty()
        {
            if (DateTime.Now.Subtract(WarrantyEndDate).TotalDays >= 1)
                return true;
            else
                return false;
        }
    }
}
