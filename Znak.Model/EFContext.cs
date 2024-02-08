﻿using Microsoft.EntityFrameworkCore;
using Znak.Model.Entities;

namespace Znak.Model
{
    public class EFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ZnakSystem> ZnakSystems { get; set; }
        public DbSet<UnitMeasure> UnitMeasures { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(Helper.DBConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ProductCategoryModelMapping(modelBuilder);
            UnitMeasureModelMapping(modelBuilder);
            ZnakSystemModelMapping(modelBuilder);
        }

        void ProductCategoryModelMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.Products)
                .WithOne(p => p.ProductCategory)
                .HasForeignKey(p => p.ProductCategoryId);
        }


        void UnitMeasureModelMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UnitMeasure>()
                .HasMany(u => u.Products)
                .WithOne(p => p.UnitMeasure)
                .HasForeignKey(p => p.UnitMeasureId);
        }

        void ZnakSystemModelMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZnakSystem>()
                .HasMany(z => z.Users)
                .WithOne(u => u.ZnakSystem)
                .HasForeignKey(u => u.ZnakSystemId);

            modelBuilder.Entity<ZnakSystem>()
                .HasMany(z => z.Customers)
                .WithOne(c => c.ZnakSystem)
                .HasForeignKey(c => c.ZnakSystemId);
        }

    }
}
