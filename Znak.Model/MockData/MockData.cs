using Znak.Model.Entities;

namespace Znak.Model.MockData
{
    public static class MockData
    {
        public static void CreateMockData(this EFContext Context)
        {
                var ZnakSystem = new ZnakSystem()
                {
                    Name = "ZnakSystem-Sanjar",
                    Phone = "123456789",
                    Email = "sanjar@gmail.com",
                    Address = "Khujand",
                    Description = string.Empty,
                };
                var userSanjar = new User()
                {
                    FirstName = "Sanjar",
                    LastName = "Akhmedov",
                    Email = "sanjar@gmail.com",
                    Phone = "927470533",
                    Address = "Khujand",
                    UserRole = UserRole.Admin,
                    Login = "sanjar",
                    Password = "sanjar",
                    Avatar = string.Empty,
                    ZnakSystem = ZnakSystem
                };

                Context.ZnakSystems.Add(ZnakSystem);
                Context.Users.Add(userSanjar);

                var ProductCategory1 = new ProductCategory()
                {
                    Name = "FirstProductCategory",
                    Description = "Very delicios"
                };
                var ProductCategory2 = new ProductCategory()
                {
                    Name = "SecondProductCategory",
                    Description = "Very delicios"
                };
                var ProductCategory3 = new ProductCategory()
                {
                    Name = "ThirdProductCategory",
                    Description = "For drinking"
                };
                Context.ProductCategories.Add(ProductCategory1);
                Context.ProductCategories.Add(ProductCategory2);
                Context.ProductCategories.Add(ProductCategory3);
                
                var unitMeasure = new UnitMeasure()
                {
                    Name = "One",
                    Description = "for one unit"
                };

                var unitMeasure1 = new UnitMeasure()
                {
                    Name = "kg",
                    Description = "for kg"
                };
                var unitMeasure2 = new UnitMeasure()
                {
                    Name = "1/2 unit",
                    Description = "for 1/2"
                };
                var unitMeasure3 = new UnitMeasure()
                {
                    Name = "1/4 unit",
                    Description = "for 1/4"
                };
                Context.UnitMeasures.Add(unitMeasure);
                Context.UnitMeasures.Add(unitMeasure1);
                Context.UnitMeasures.Add(unitMeasure2);
                Context.UnitMeasures.Add(unitMeasure3);

                var Product1 = new Product()
                {
                    Name = "Osh",
                    Description = "National Product. Very good",
                    Price = 14,
                    ProductCategory = ProductCategory1,
                    UnitMeasure = unitMeasure,
                };
                var Product2 = new Product()
                {
                    Name = "Kebab",
                    Description = "National Product. Very good",
                    Price = 18,
                    ProductCategory = ProductCategory1,
                    UnitMeasure = unitMeasure,
                };
                Context.Products.Add(Product1);
                Context.Products.Add(Product2);
                
                Context.SaveChanges();
        }
    }
}