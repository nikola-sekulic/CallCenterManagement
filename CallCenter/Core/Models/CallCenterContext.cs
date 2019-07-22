using System;
using CallCenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CallCenter.Core.Models
{
    public partial class CallCenterContext : DbContext,IApplicationDbContext
    {
        public CallCenterContext()
        {
        }

        public CallCenterContext(DbContextOptions<CallCenterContext> options)
            : base(options)
        {
        }

        public  DbSet<AspNetRoles> AspNetRoles { get; set; }
        public  DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public  DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public  DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public  DbSet<AspNetUsers> AspNetUsers { get; set; }
        public  DbSet<Buyers> Buyers { get; set; }
        public  DbSet<CallHistories> CallHistories { get; set; }
        public  DbSet<Departments> Departments { get; set; }
        public  DbSet<Designations> Designations { get; set; }
        public  DbSet<DeviceSuppliers> DeviceSuppliers { get; set; }
        public  DbSet<Employees> Employees { get; set; }
        public  DbSet<MigrationHistory> MigrationHistory { get; set; }
        public  DbSet<Notifications> Notifications { get; set; }
        public  DbSet<Reclamations> Reclamations { get; set; }
        public  DbSet<ReclamationTypes> ReclamationTypes { get; set; }
        public  DbSet<SoldDevices> SoldDevices { get; set; }
        public  DbSet<UserNotifications> UserNotifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-CallCenterManagementSystem-20190320045035;integrated security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Buyers>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CallHistories>(entity =>
            {
                entity.HasIndex(e => e.BuyerId)
                    .HasName("IX_BuyerId");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.Property(e => e.CallDate).HasColumnType("datetime");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.CallHistories)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK_dbo.CallHistories_dbo.Buyers_BuyerId");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Designations>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DeviceSuppliers>(entity =>
            {
                entity.HasKey(e => e.CompamyName);

                entity.Property(e => e.CompamyName)
                    .HasMaxLength(25)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_DepartmentId");

                entity.HasIndex(e => e.DesignationId)
                    .HasName("IX_DesignationId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.DateEnded).HasColumnType("datetime");

                entity.Property(e => e.DateStarted).HasColumnType("datetime");

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Qualification)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_dbo.Employees_dbo.Departments_DepartmentId");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_dbo.Employees_dbo.Designations_DesignationId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.Employees_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.HasIndex(e => e.ReclamationId)
                    .HasName("IX_Reclamation_Id");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.ReclamationId).HasColumnName("Reclamation_Id");

                entity.HasOne(d => d.Reclamation)
                    .WithMany(p => p.NotificationsCollection)
                    .HasForeignKey(d => d.ReclamationId)
                    .HasConstraintName("FK_dbo.Notifications_dbo.Reclamations_Reclamation_Id");
            });

            modelBuilder.Entity<Reclamations>(entity =>
            {
                entity.HasIndex(e => e.AgentId)
                    .HasName("IX_AgentId");

                entity.HasIndex(e => e.ReclamationTypeId)
                    .HasName("IX_ReclamationTypeId");

                entity.HasIndex(e => e.SoldDeviceId)
                    .HasName("IX_SoldDeviceId");

                entity.HasIndex(e => e.SpecialistId)
                    .HasName("IX_SpecialistId");

                entity.Property(e => e.ProblemDescription)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ReclamationCreated).HasColumnType("datetime");

                entity.Property(e => e.ReclamationEnded).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ReclamationType)
                    .WithMany(p => p.Reclamations)
                    .HasForeignKey(d => d.ReclamationTypeId)
                    .HasConstraintName("FK_dbo.Reclamations_dbo.ReclamationTypes_ReclamationTypeId");

                entity.HasOne(d => d.SoldDevice)
                    .WithMany(p => p.Reclamations)
                    .HasForeignKey(d => d.SoldDeviceId)
                    .HasConstraintName("FK_dbo.Reclamations_dbo.SoldDevices_SoldDeviceId");
            });

            modelBuilder.Entity<ReclamationTypes>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SoldDevices>(entity =>
            {
                entity.HasIndex(e => e.BuyerId)
                    .HasName("IX_BuyerId");

                entity.HasIndex(e => e.DeviceSupplierCompamyName)
                    .HasName("IX_DeviceSupplier_CompamyName");

                entity.Property(e => e.DeviceSupplierCompamyName)
                    .HasColumnName("DeviceSupplier_CompamyName")
                    .HasMaxLength(25);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WarrantyEndDate).HasColumnType("datetime");

                entity.Property(e => e.WarrantyStartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.SoldDevices)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK_dbo.SoldDevices_dbo.Buyers_BuyerId");

                entity.HasOne(d => d.DeviceSupplierCompamyNameNavigation)
                    .WithMany(p => p.SoldDevices)
                    .HasForeignKey(d => d.DeviceSupplierCompamyName)
                    .HasConstraintName("FK_dbo.SoldDevices_dbo.DeviceSuppliers_DeviceSupplier_CompamyName");
            });

            modelBuilder.Entity<UserNotifications>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.NotificationId });

                entity.HasIndex(e => e.NotificationId)
                    .HasName("IX_NotificationId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.IsRead).HasColumnName("isRead");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.UserNotifications)
                    .HasForeignKey(d => d.NotificationId)
                    .HasConstraintName("FK_dbo.UserNotifications_dbo.Notifications_NotificationId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserNotifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.UserNotifications_dbo.AspNetUsers_UserId");
            });
        }
    }
}
