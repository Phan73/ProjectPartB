using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectPartB.Areas.Identity.Data;

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


        public virtual DbSet<CarAvailability> CarAvailabilities { get; set; } = null!;
        public virtual DbSet<CarDescription> CarDescriptions { get; set; } = null!;
        public virtual DbSet<CarType> CarTypes { get; set; } = null!;
  
        public virtual DbSet<UserDescription> UserDescriptions { get; set; } = null!;
        public virtual DbSet<UserEnum> UserEnums { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

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
            modelBuilder.Entity<WebUser>()
      .HasOne(u => u.Membership) // navigation property in WebUser class
      .WithOne(m => m.User)      // navigation property in Membership class
      .HasForeignKey<Membership>(m => m.UserId);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
