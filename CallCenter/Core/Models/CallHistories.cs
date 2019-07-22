using System;
using System.Collections.Generic;

namespace CallCenter.Core.Models
{
    public partial class CallHistories
    {
        public int Id { get; set; }
        public DateTime CallDate { get; set; }
        public int BuyerId { get; set; }
        public int EmployeeId { get; set; }

        public Buyers Buyer { get; set; }
        public Employees Employee { get; set; }
    }
}
