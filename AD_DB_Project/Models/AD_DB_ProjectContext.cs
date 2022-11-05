using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AD_DB_Project.Models
{
    public partial class AD_DB_ProjectContext : IdentityDbContext<IdentityUser>
    {
        public AD_DB_ProjectContext()
        {
        }

        public AD_DB_ProjectContext(DbContextOptions<AD_DB_ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airplane> Airplane { get; set; }
        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeAudit> EmployeeAudit { get; set; }
        public virtual DbSet<Supervisor> Supervisor { get; set; }
        public virtual DbSet<Technician> Technician { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestAudit> TestAudit { get; set; }
        public virtual DbSet<TrafficController> TrafficController { get; set; }
        public virtual DbSet<WorkStaff> WorkStaff { get; set; }
        public virtual DbSet<WorkerUnion> WorkerUnion { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Airplane>(entity =>
            {
                entity.HasKey(e => e.RegNum)
                    .HasName("PK_RN");

                entity.ToTable("AIRPLANE");

                entity.Property(e => e.RegNum)
                    .HasColumnName("reg_num")
                    .ValueGeneratedNever();

                entity.Property(e => e.AirportCode)
                    .HasColumnName("airport_code")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.AirportCodeNavigation)
                    .WithMany(p => p.Airplane)
                    .HasForeignKey(d => d.AirportCode)
                    .HasConstraintName("FK_AirPort");
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(e => e.AirportCode)
                    .HasName("PK_AC");

                entity.ToTable("AIRPORT");

                entity.Property(e => e.AirportCode)
                    .HasColumnName("airport_code")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.AirportCity)
                    .HasColumnName("airport_city")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AirportName)
                    .HasColumnName("airport_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AirportParish)
                    .HasColumnName("airport_state")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => new { e.UMembership, e.Trn })
                    .HasName("PK_Category");

                entity.ToTable("CATEGORY");

                entity.Property(e => e.UMembership)
                    .HasColumnName("u_membership")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Trn).HasColumnName("trn");

                entity.HasOne(d => d.TrnNavigation)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.Trn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_memberTrn");

                entity.HasOne(d => d.UMembershipNavigation)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.UMembership)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_member");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Trn)
                    .HasName("PK_TRN");

                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Trn)
                    .HasColumnName("trn")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FName)
                    .HasColumnName("f_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LName)
                    .HasColumnName("l_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MName)
                    .HasColumnName("m_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("decimal(9, 2)");

                entity.Property(e => e.Tel).HasColumnName("tel");
            });

            modelBuilder.Entity<EmployeeAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Employee_Audit");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AuditAction)
                    .HasColumnName("audit_action")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AuditDate)
                    .HasColumnName("audit_date")
                    .HasColumnType("date");

                entity.Property(e => e.FName)
                    .HasColumnName("f_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LName)
                    .HasColumnName("l_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MName)
                    .HasColumnName("m_name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("decimal(9, 2)");

                entity.Property(e => e.Tel).HasColumnName("tel");

                entity.Property(e => e.Trn).HasColumnName("trn");
            });

            modelBuilder.Entity<Supervisor>(entity =>
            {
                entity.HasKey(e => new { e.Trn, e.Start, e.Employee })
                    .HasName("PK_sup_trn");

                entity.ToTable("SUPERVISOR");

                entity.Property(e => e.Trn).HasColumnName("trn");

                entity.Property(e => e.Start)
                    .HasColumnName("start")
                    .HasColumnType("date");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.TrnNavigation)
                    .WithMany(p => p.Supervisor)
                    .HasForeignKey(d => d.Trn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_empnum");
            });

            modelBuilder.Entity<Technician>(entity =>
            {
                entity.HasKey(e => e.Trn)
                    .HasName("PK_TechTrn");

                entity.ToTable("TECHNICIAN");

                entity.Property(e => e.Trn)
                    .HasColumnName("trn")
                    .ValueGeneratedNever();

                entity.Property(e => e.Expertise)
                    .HasColumnName("expertise")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Restriction)
                    .HasColumnName("restriction")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.TrnNavigation)
                    .WithOne(p => p.Technician)
                    .HasForeignKey<Technician>(d => d.Trn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechTrn");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasKey(e => e.FaaNum)
                    .HasName("PK_FN");

                entity.ToTable("TEST");

                entity.Property(e => e.FaaNum)
                    .HasColumnName("faa_num")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.MaxScore).HasColumnName("max_score");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.RegNum).HasColumnName("reg_num");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.TestHours).HasColumnName("test_hours");

                entity.HasOne(d => d.RegNumNavigation)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.RegNum)
                    .HasConstraintName("FK_RN");
            });

            modelBuilder.Entity<TestAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Test_Audit");

                entity.Property(e => e.AuditAction)
                    .HasColumnName("audit_action")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AuditDate)
                    .HasColumnName("audit_date")
                    .HasColumnType("date");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.FaaNum).HasColumnName("faa_num");

                entity.Property(e => e.MaxScore).HasColumnName("max_score");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.RegNum).HasColumnName("reg_num");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.TestHours).HasColumnName("test_hours");
            });

            modelBuilder.Entity<TrafficController>(entity =>
            {
                entity.HasKey(e => e.Trn)
                    .HasName("PK_TrafficTrn");

                entity.ToTable("Traffic_Controller");

                entity.Property(e => e.Trn)
                    .HasColumnName("trn")
                    .ValueGeneratedNever();

                entity.Property(e => e.Exam)
                    .HasColumnName("exam")
                    .HasColumnType("date");

                entity.HasOne(d => d.TrnNavigation)
                    .WithOne(p => p.TrafficController)
                    .HasForeignKey<TrafficController>(d => d.Trn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrafficTrn");
            });

            modelBuilder.Entity<WorkStaff>(entity =>
            {
                entity.HasKey(e => new { e.AirportCode, e.Trn, e.StartDate })
                    .HasName("PK_Staff");

                entity.ToTable("Work_Staff");

                entity.Property(e => e.AirportCode)
                    .HasColumnName("airport_code")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Trn).HasColumnName("trn");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.AirportCodeNavigation)
                    .WithMany(p => p.WorkStaff)
                    .HasForeignKey(d => d.AirportCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AC");

                entity.HasOne(d => d.TrnNavigation)
                    .WithMany(p => p.WorkStaff)
                    .HasForeignKey(d => d.Trn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRN");
            });

            modelBuilder.Entity<WorkerUnion>(entity =>
            {
                entity.HasKey(e => e.UMembership)
                    .HasName("PK_member");

                entity.ToTable("WORKER_UNION");

                entity.Property(e => e.UMembership)
                    .HasColumnName("u_membership")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UName)
                    .HasColumnName("u_name")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.UPresident).HasColumnName("u_president");

                entity.HasOne(d => d.UPresidentNavigation)
                    .WithMany(p => p.WorkerUnion)
                    .HasForeignKey(d => d.UPresident)
                    .HasConstraintName("FK_Pres");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
