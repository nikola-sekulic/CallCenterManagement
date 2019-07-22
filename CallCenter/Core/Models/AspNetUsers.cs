using System;
using System.Collections.Generic;

namespace CallCenter.Core.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            Employees = new HashSet<Employees>();
            UserNotifications = new HashSet<UserNotifications>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }

        public ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public ICollection<Employees> Employees { get; set; }
        public ICollection<UserNotifications> UserNotifications { get; set; }

        public void Notify(Notifications notification)
        {
            UserNotifications.Add(new UserNotifications(this, notification));
        }
    }
}
