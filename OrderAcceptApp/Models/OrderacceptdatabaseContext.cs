using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrderAcceptApp.Models;

public partial class OrderacceptdatabaseContext : DbContext
{
    public OrderacceptdatabaseContext()
    {
    }

    public OrderacceptdatabaseContext(DbContextOptions<OrderacceptdatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Subdivision> Subdivisions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;user=root;password=1234;database=orderacceptdatabase", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequsetId).HasName("PRIMARY");

            entity.ToTable("requests");

            entity.HasIndex(e => e.ServiceId, "serviceid_idx");

            entity.HasIndex(e => e.UserId, "userid_idx");

            entity.Property(e => e.RequsetId)
                .ValueGeneratedNever()
                .HasColumnName("requset_id");
            entity.Property(e => e.RequestDate).HasColumnName("request_date");
            entity.Property(e => e.RequestDecsription)
                .HasMaxLength(150)
                .HasColumnName("request_decsription");
            entity.Property(e => e.RequestTheme)
                .HasMaxLength(45)
                .HasColumnName("request_theme");
            entity.Property(e => e.Response)
                .HasMaxLength(45)
                .HasColumnName("response");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Service).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("serviceid");

            entity.HasOne(d => d.User).WithMany(p => p.Requests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("userid");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PRIMARY");

            entity.ToTable("services");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("service_id");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(45)
                .HasColumnName("service_name");
        });

        modelBuilder.Entity<Subdivision>(entity =>
        {
            entity.HasKey(e => e.SubdivisionId).HasName("PRIMARY");

            entity.ToTable("subdivisions");

            entity.Property(e => e.SubdivisionId)
                .ValueGeneratedNever()
                .HasColumnName("subdivision_id");
            entity.Property(e => e.SubdivisionName)
                .HasMaxLength(45)
                .HasColumnName("subdivision_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.UserSubdivisionid, "subdiv_id_idx");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.UserLogin)
                .HasMaxLength(45)
                .HasColumnName("user_login");
            entity.Property(e => e.UserName)
                .HasMaxLength(45)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(45)
                .HasColumnName("user_password");
            entity.Property(e => e.UserPatronymic)
                .HasMaxLength(45)
                .HasColumnName("user_patronymic");
            entity.Property(e => e.UserSubdivisionid).HasColumnName("user_subdivisionid");
            entity.Property(e => e.UserSurname)
                .HasMaxLength(45)
                .HasColumnName("user_surname");

            entity.HasOne(d => d.UserSubdivision).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserSubdivisionid)
                .HasConstraintName("subdiv_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
