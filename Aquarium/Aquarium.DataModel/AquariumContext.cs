using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Aquarium.DataModel
{
    public partial class AquariumContext : DbContext
    {
        public AquariumContext()
        {
        }

        public AquariumContext(DbContextOptions<AquariumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("Animal", "Aquarium");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Price).HasColumnType("smallmoney");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "Aquarium");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory", "Aquarium");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.AnimalId)
                    .HasConstraintName("FK__Inventory__Anima__5EBF139D");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Inventory_StoreId");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders", "Aquarium");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("(getdatetime())");

                entity.Property(e => e.Total).HasColumnType("smallmoney");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AnimalId)
                    .HasConstraintName("FK_Orders_AnimalId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__66603565");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Orders__StoreId__656C112C");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "Aquarium");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
