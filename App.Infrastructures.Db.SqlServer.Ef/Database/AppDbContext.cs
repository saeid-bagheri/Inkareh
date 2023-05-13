using System;
using System.Collections.Generic;
using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Db.SqlServer.Ef.Database;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bid> Bids { get; set; }

    public virtual DbSet<BidStatus> BidStatuses { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<Expert> Experts { get; set; }

    public virtual DbSet<ExpertService> ExpertServices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderService> OrderServices { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=db_Inkareh;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bid>(entity =>
        {
            entity.HasIndex(e => e.ExpertId, "IX_Bids_ExpertId");

            entity.HasIndex(e => e.OrderId, "IX_Bids_OrderId");

            entity.HasIndex(e => e.StatusId, "IX_Bids_StatusId");

            entity.Property(e => e.ExpertSuggestionComment).HasMaxLength(2000);

            entity.HasOne(d => d.Expert).WithMany(p => p.Bids)
                .HasForeignKey(d => d.ExpertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bids_Experts");

            entity.HasOne(d => d.Order).WithMany(p => p.Bids)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bids_Orders");

            entity.HasOne(d => d.Status).WithMany(p => p.Bids)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bids_BidStatuses");
        });

        modelBuilder.Entity<BidStatus>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.BackupMobileNumber).HasMaxLength(11);
            entity.Property(e => e.FirstName).HasMaxLength(250);
            entity.Property(e => e.LastName).HasMaxLength(250);
            entity.Property(e => e.MobileNumber).HasMaxLength(11);
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_CustomerAddresses_CustomerId");

            entity.Property(e => e.CityRegionTitle).HasMaxLength(250);
            entity.Property(e => e.FullAddress).HasMaxLength(500);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerAddresses_Customers");
        });

        modelBuilder.Entity<Expert>(entity =>
        {
            entity.HasIndex(e => e.CityId, "IX_Experts_CityId");

            entity.Property(e => e.BackupMobileNumber).HasMaxLength(11);
            entity.Property(e => e.CompanyName).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(250);
            entity.Property(e => e.HomeAddress).HasMaxLength(500);
            entity.Property(e => e.LastName).HasMaxLength(250);
            entity.Property(e => e.MobileNumber).HasMaxLength(11);

            entity.HasOne(d => d.City).WithMany(p => p.Experts)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Experts_Cities");
        });

        modelBuilder.Entity<ExpertService>(entity =>
        {
            entity.HasIndex(e => e.ExpertId, "IX_ExpertServices_ExpertId");

            entity.HasIndex(e => e.ServiceId, "IX_ExpertServices_ServiceId");

            entity.HasOne(d => d.Expert).WithMany(p => p.ExpertServices)
                .HasForeignKey(d => d.ExpertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExpertServices_Experts");

            entity.HasOne(d => d.Service).WithMany(p => p.ExpertServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExpertServices_Services");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerId");

            entity.HasIndex(e => e.StatusId, "IX_Orders_StatusId");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_OrderStatues");
        });

        modelBuilder.Entity<OrderService>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IX_OrderServices_OrderId");

            entity.HasIndex(e => e.ServiceId, "IX_OrderServices_ServiceId");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderServices_Orders");

            entity.HasOne(d => d.Service).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderServices_Services");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Services_CategoryId");

            entity.Property(e => e.Title).HasMaxLength(250);

            entity.HasOne(d => d.Category).WithMany(p => p.Services)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Services_ServiceCategories");
        });

        modelBuilder.Entity<ServiceCategory>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
