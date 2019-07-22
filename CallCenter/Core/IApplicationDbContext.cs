using CallCenter.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CallCenter.Models
{
    public interface IApplicationDbContext
    {
        DbSet<AspNetRoles> AspNetRoles { get; set; }
          DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
          DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
          DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
          DbSet<AspNetUsers> AspNetUsers { get; set; }
          DbSet<Buyers> Buyers { get; set; }
          DbSet<CallHistories> CallHistories { get; set; }
          DbSet<Departments> Departments { get; set; }
          DbSet<Designations> Designations { get; set; }
          DbSet<DeviceSuppliers> DeviceSuppliers { get; set; }
          DbSet<Employees> Employees { get; set; }
          DbSet<MigrationHistory> MigrationHistory { get; set; }
          DbSet<Notifications> Notifications { get; set; }
          DbSet<Reclamations> Reclamations { get; set; }
          DbSet<ReclamationTypes> ReclamationTypes { get; set; }
          DbSet<SoldDevices> SoldDevices { get; set; }
          DbSet<UserNotifications> UserNotifications { get; set; }
    }
}