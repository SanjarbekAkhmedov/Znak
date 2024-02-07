using Microsoft.EntityFrameworkCore;
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
            UserModelMapping(modelBuilder);
            CustomerModelMapping(modelBuilder);
            ProductModelMapping(modelBuilder);
            ProductCategoryModelMapping(modelBuilder);
            UnitMeasureModelMapping(modelBuilder);
            ZnakSystemModelMapping(modelBuilder);
        }
        void UserModelMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
        }
        void CustomerModelMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(u => u.Id);
        }
        void ProductModelMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(u => u.Id);
        }
        void ProductCategoryModelMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(u => u.Id);
            modelBuilder.Entity<ProductCategory>().HasMany(f => f.Products).WithOne(f => f.ProductCategory).HasForeignKey(s => s.ProductCategoryId);
        }
        void UnitMeasureModelMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UnitMeasure>().HasKey(u => u.Id);
            modelBuilder.Entity<UnitMeasure>().HasMany(f => f.Products).WithOne(f => f.UnitMeasure).HasForeignKey(s => s.UnitMeasureId);
        }
        void ZnakSystemModelMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZnakSystem>().HasKey(u => u.Id);
            modelBuilder.Entity<ZnakSystem>().HasMany<User>(s => s.Users).WithOne(s => s.ZnakSystem).HasForeignKey(s => s.ZnakSystemId);
            modelBuilder.Entity<ZnakSystem>().HasMany<Customer>(s => s.Customers).WithOne(s => s.ZnakSystem).HasForeignKey(s => s.ZnakSystemId);
        }
    }
}
