using System;
using System.Collections.Generic;
using HR_Employess_DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HR_Employess_DataAccess
{
    public partial class HR_CompanyContext : DbContext
    {
        public HR_CompanyContext()
        {
        }

        public HR_CompanyContext(DbContextOptions<HR_CompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeesLogin> EmployeesLogins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.92.150;Database=HR_Company;PERSIST SECURITY INFO=True;USER ID=sa;password=P@$$w0rd;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.EmployeeName, "NonClusteredIndex-20221020-190700");

                entity.HasIndex(e => e.IsManager, "NonClusteredIndex-20221021-133711");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeAddress)
                    .HasMaxLength(30)
                    .HasColumnName("Employee_Address");

                entity.Property(e => e.EmployeeBirthDate)
                    .HasColumnType("date")
                    .HasColumnName("Employee_BirthDate");

                entity.Property(e => e.EmployeeEmailAddress)
                    .HasMaxLength(30)
                    .HasColumnName("Employee_EmailAddress");

                entity.Property(e => e.EmployeeMobile)
                    .HasMaxLength(30)
                    .HasColumnName("Employee_Mobile");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(30)
                    .HasColumnName("Employee_Name");

                entity.Property(e => e.IsManager).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("emp_mang");
            });

            modelBuilder.Entity<EmployeesLogin>(entity =>
            {
                entity.ToTable("EmployeesLogin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_Date");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.SignInTime).HasColumnName("SignIn_Time");

                entity.Property(e => e.SignOutTime).HasColumnName("SignOut_Time");

                entity.Property(e => e.TotalHours)
                    .HasColumnName("Total_Hours")
                    .HasComputedColumnSql("(datediff(hour,[SignIn_Time],[SignOut_Time]))", false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeesLogins)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employees__Emplo__4222D4EF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
