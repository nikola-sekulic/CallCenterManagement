using System;
using System.Collections.Generic;

namespace CallCenter.Core.Models
{
    public partial class Reclamations
    {
        public Reclamations()
        {
            NotificationsCollection = new HashSet<Notifications>();
        }

        public int Id { get; set; }
        public string ProblemDescription { get; set; }
        public string Status { get; set; }
        public int AgentId { get; set; }
        public int SpecialistId { get; set; }
        public int SoldDeviceId { get; set; }
        public DateTime ReclamationCreated { get; set; }
        public DateTime? ReclamationEnded { get; set; }
        public int ReclamationTypeId { get; set; }

        public Employees Agent { get; set; }

        public ReclamationTypes ReclamationType { get; set; }
        public SoldDevices SoldDevice { get; set; }
        public Employees Specialist { get; set; }
        public ICollection<Notifications> NotificationsCollection { get; set; }

        public void Create()
        {
            var notification = Notifications.ReclamationCreated(this);

            Agent.User.Notify(notification);
        }
    }
}
