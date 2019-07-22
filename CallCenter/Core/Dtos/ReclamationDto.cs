using CallCenter.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CallCenter.Core.Dtos
{
    public class ReclamationDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProblemDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        


        public Employees Specialist { get; set; }

        [Required]
        public int SpecialistId { get; set; }

        public SoldDevices SoldDevice { get; set; }

        [Required]
        public int SoldDeviceId { get; set; }

        [Required]
        public DateTime ReclamationCreated { get; set; }

        public DateTime? ReclamationEnded { get; set; }

        public ReclamationTypes ReclamationType { get; set; }

        [Required]
        public int ReclamationTypeId { get; set; }
    }
}