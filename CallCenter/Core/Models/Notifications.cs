using System;
using System.Collections.Generic;

namespace CallCenter.Core.Models
{
    public partial class Notifications
    {
        public Notifications()
        {
            UserNotifications = new HashSet<UserNotifications>();
        }

        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int ReclamationId { get; set; }
        public NotificationType Type { get; set; }

        public Reclamations Reclamation { get; set; }
        public ICollection<UserNotifications> UserNotifications { get; set; }


        private Notifications(NotificationType type, Reclamations reclamation)
        {
            if (reclamation == null)
                throw new ArgumentNullException("reclamation");

            Type = type;
            Reclamation = reclamation;
            DateTime = DateTime.Now;
        }

        

        public static Notifications ReclamationCreated(Reclamations reclamation)
        {
            return new Notifications(NotificationType.ReclamationCreated, reclamation);
        }
    }
}
