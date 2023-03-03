using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace YaKisuhShopApi.Models
{
    public partial class YaKisuhShopContext : DbContext
    {
        public YaKisuhShopContext()
        {
        }

        public YaKisuhShopContext(DbContextOptions<YaKisuhShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Good> Goods { get; set; } = null!;
        public virtual DbSet<GoodImage> GoodImages { get; set; } = null!;
        public virtual DbSet<GoodType> GoodTypes { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Good>(entity =>
            {
                entity.ToTable("Good");

                entity.Property(e => e.GoodDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.GoodName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.GoodTypeNavigation)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.GoodType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Good__GoodType__4CA06362");
            });

            modelBuilder.Entity<GoodImage>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK__GoodImag__7516F70C8E15C90B");

                entity.ToTable("GoodImage");

                entity.HasIndex(e => e.ImageLink, "UQ__GoodImag__CF729F9A84B6079E")
                    .IsUnique();

                entity.Property(e => e.ImageLink)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.GoodImages)
                    .HasForeignKey(d => d.GoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GoodImage__GoodI__5070F446");
            });

            modelBuilder.Entity<GoodType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__GoodType__516F03B5BCFB447F");

                entity.ToTable("GoodType");

                entity.HasIndex(e => e.TypeName, "UQ__GoodType__D4E7DFA8006EF401")
                    .IsUnique();

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sale");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SaleDate).HasColumnType("datetime");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.GoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sale__GoodId__534D60F1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
