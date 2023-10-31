using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectPartB.Models
{
    public partial class FS23_Group4_ProjectContext : DbContext
    {
        public FS23_Group4_ProjectContext()
        {
        }

        public FS23_Group4_ProjectContext(DbContextOptions<FS23_Group4_ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<CarAvailability> CarAvailabilities { get; set; } = null!;
        public virtual DbSet<CarDescription> CarDescriptions { get; set; } = null!;
        public virtual DbSet<CarType> CarTypes { get; set; } = null!;
        public virtual DbSet<Rental> Rentals { get; set; } = null!;
        public virtual DbSet<UserDescription> UserDescriptions { get; set; } = null!;
        public virtual DbSet<UserEnum> UserEnums { get; set; } = null!;

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CarAvailability>(entity =>
            {
                entity.ToTable("CarAvailability");

                entity.HasOne(d => d.CarDescription)
                    .WithMany(p => p.CarAvailabilities)
                    .HasForeignKey(d => d.CarDescriptionId)
                    .HasConstraintName("FK__CarAvaila__CarDe__395884C4");
            });

            modelBuilder.Entity<CarDescription>(entity =>
            {
                entity.ToTable("CarDescription");

                entity.Property(e => e.Available).HasDefaultValueSql("((1))");

                entity.Property(e => e.Brand).HasMaxLength(50);

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.RatePerDay).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.CarType)
                    .WithMany(p => p.CarDescriptions)
                    .HasForeignKey(d => d.CarTypeId)
                    .HasConstraintName("FK__CarDescri__CarTy__2BFE89A6");
            });

            modelBuilder.Entity<CarType>(entity =>
            {
                entity.ToTable("CarType");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.ToTable("Rental");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TotalCost).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.CarDescription)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CarDescriptionId)
                    .HasConstraintName("FK__Rental__CarDescr__3587F3E0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Rental__UserId__367C1819");
            });

            modelBuilder.Entity<UserDescription>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserDesc__1788CC4C44B75D43");

                entity.ToTable("UserDescription");

                entity.HasIndex(e => e.Email, "UQ__UserDesc__A9D105347F65302D")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.HasOne(d => d.UserEnum)
                    .WithMany(p => p.UserDescriptions)
                    .HasForeignKey(d => d.UserEnumId)
                    .HasConstraintName("FK__UserDescr__UserE__32AB8735");
            });

            modelBuilder.Entity<UserEnum>(entity =>
            {
                entity.ToTable("UserEnum");

                entity.Property(e => e.UserEnumId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
