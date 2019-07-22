using System;
using System.Collections.Generic;

namespace CallCenter.Core.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Employees = new HashSet<Employees>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employees> Employees { get; set; }
    }
}
