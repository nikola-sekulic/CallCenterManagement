using System;
using System.Collections.Generic;

namespace CallCenter.Core.Models
{
    public partial class ReclamationTypes
    {
        public ReclamationTypes()
        {
            Reclamations = new HashSet<Reclamations>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Reclamations> Reclamations { get; set; }
    }
}
