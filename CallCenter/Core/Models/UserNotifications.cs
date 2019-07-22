using System;
using System.Collections.Generic;

namespace CallCenter.Core.Models
{
    public partial class UserNotifications
    {
        public string UserId { get; set; }
        public int NotificationId { get; set; }
        public bool IsRead { get; set; }

        public Notifications Notification { get; set; }
        public AspNetUsers User { get; set; }

        public UserNotifications()
        {

        }

        public UserNotifications(AspNetUsers user, Notifications notification)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (notification == null)
                throw new ArgumentNullException("notification");

            User = user;
            Notification = notification;
        }

        public void Read()
        {
            IsRead = true;
        }
    }
}
