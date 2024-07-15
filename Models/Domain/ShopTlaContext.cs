using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShopTLA.Models.Domain;

public partial class ShopTlaContext : DbContext
{
    public ShopTlaContext()
    {
    }

    public ShopTlaContext(DbContextOptions<ShopTlaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Nation> Nations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-48JPN0S\\MSSQLSERVER01;Database=ShopTLA;TrustServerCertificate=True;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__Categori__6A1C8AFA1C46400F");

            entity.Property(e => e.CatDescription).HasMaxLength(100);
            entity.Property(e => e.CatLastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CatName).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CusId).HasName("PK__Customer__2F187110E88EB5DF");

            entity.Property(e => e.CusId).ValueGeneratedNever();
            entity.Property(e => e.CusAddress).HasMaxLength(100);
            entity.Property(e => e.CusDateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.CusEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CusLastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CusName).HasMaxLength(50);
            entity.Property(e => e.CusPhone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Cus).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.CusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customers__CusId__2B3F6F97");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBB992BF77CF3");

            entity.Property(e => e.EmpId).ValueGeneratedNever();
            entity.Property(e => e.EmpAddress).HasMaxLength(100);
            entity.Property(e => e.EmpDateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.EmpEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmpLastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmpName).HasMaxLength(50);
            entity.Property(e => e.EmpPhone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Emp).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__EmpId__2F10007B");
        });

        modelBuilder.Entity<Nation>(entity =>
        {
            entity.HasKey(e => e.NatId).HasName("PK__Nations__668041083B4A3E5A");

            entity.Property(e => e.NatLastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NatName).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdId).HasName("PK__Orders__67A28336A51F5815");

            entity.Property(e => e.OrdDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrdLastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Cus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CusId)
                .HasConstraintName("FK__Orders__CusId__3D5E1FD2");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.DetId).HasName("PK__OrderDet__D8957ADCAEF05231");

            entity.Property(e => e.DetLastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Ord).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrdId)
                .HasConstraintName("FK__OrderDeta__OrdId__4222D4EF");

            entity.HasOne(d => d.Pro).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProId)
                .HasConstraintName("FK__OrderDeta__ProId__4316F928");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProId).HasName("PK__Products__6202959091DE12B0");

            entity.Property(e => e.ProDescription).HasMaxLength(100);
            entity.Property(e => e.ProLastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProName).HasMaxLength(50);

            entity.HasOne(d => d.Cat).WithMany(p => p.Products)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK__Products__CatId__38996AB5");

            entity.HasOne(d => d.Nat).WithMany(p => p.Products)
                .HasForeignKey(d => d.NatId)
                .HasConstraintName("FK__Products__NatId__398D8EEE");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserAcco__3214EC07D547027E");

            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PassWord)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.TypeUserNavigation).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.TypeUser)
                .HasConstraintName("FK__UserAccou__TypeU__267ABA7A");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.TypeUser).HasName("PK__UserType__E1F318E8051A5C84");

            entity.Property(e => e.TypeUser).ValueGeneratedNever();
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

