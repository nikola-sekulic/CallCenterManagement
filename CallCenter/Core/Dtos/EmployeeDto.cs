﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CallCenter.Core.Dtos
{
    public class EmployeeDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime DateStarted { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateEnded { get; set; }

        [Required]
        [StringLength(100)]
        public string Qualification { get; set; }

        public int DepartmentId { get; set; }
        public DepartmentDto Department { get; set; }


        public int DesignationId { get; set; }
        public DesignationDto Designation { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}