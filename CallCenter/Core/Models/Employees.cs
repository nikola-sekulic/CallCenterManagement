using System;
using System.Collections.Generic;

namespace CallCenter.Core.Models
{
    public partial class Employees
    {
        public Employees()
        {
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }
        public string Qualification { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public string Gender { get; set; }
        public int? SupervisorId { get; set; }
        public string Discriminator { get; set; }

        public Departments Department { get; set; }
        public Designations Designation { get; set; }
        public AspNetUsers User { get; set; }
    }
}
