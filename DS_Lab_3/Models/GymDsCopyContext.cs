using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DS_Lab_3.Models;

public partial class GymDsCopyContext : DbContext
{
    public GymDsCopyContext()
    {
    }

    public GymDsCopyContext(DbContextOptions<GymDsCopyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bathhousereservation> Bathhousereservations { get; set; }

    public virtual DbSet<Boughtshopitem> Boughtshopitems { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Locker> Lockers { get; set; }

    public virtual DbSet<Lockerassignment> Lockerassignments { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Shopitem> Shopitems { get; set; }

    public virtual DbSet<Trainersession> Trainersessions { get; set; }

    public virtual DbSet<Workoutclass> Workoutclasses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("data source=localhost,3306;initial catalog=gym_ds_copy;user id=root;password=1111", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Bathhousereservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bathhousereservation");

            entity.Property(e => e.Id).HasColumnName("reservation_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.ReservationTime)
                .HasColumnType("time")
                .HasColumnName("reservation_time");
            entity.Property(e => e.ReservedHours).HasColumnName("reserved_hours");
        });

        modelBuilder.Entity<Boughtshopitem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("boughtshopitems");

            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.Id).HasColumnName("membership_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmployeeEmail)
                .HasMaxLength(255)
                .HasColumnName("employee_email");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<EmployeeRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employee_roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("invoice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
        });

        modelBuilder.Entity<Locker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("locker");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsAvailable).HasColumnName("is_available");
            entity.Property(e => e.LockerNumber)
                .HasMaxLength(10)
                .HasColumnName("locker_number");
        });

        modelBuilder.Entity<Lockerassignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lockerassignment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignmentDate).HasColumnName("assignment_date");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.LockerId).HasColumnName("locker_id");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("membership");

            entity.Property(e => e.Id).HasColumnName("membership_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.MemberEmail)
                .HasMaxLength(255)
                .HasColumnName("member_email");
            entity.Property(e => e.MemberPhone)
                .HasMaxLength(15)
                .HasColumnName("member_phone");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("payment");

            entity.Property(e => e.Id).HasColumnName("payment_id");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.PaymentAmount)
                .HasPrecision(10, 2)
                .HasColumnName("payment_amount");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
        });

        modelBuilder.Entity<Shopitem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("shopitem");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.StockQuantity).HasColumnName("stock_quantity");
        });

        modelBuilder.Entity<Trainersession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("trainersession");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");
        });

        modelBuilder.Entity<Workoutclass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("workoutclass");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.InstructorId).HasColumnName("instructor_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Schedule)
                .HasMaxLength(255)
                .HasColumnName("schedule");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
