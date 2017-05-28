namespace PetStoreMvc.Migrations
{
    using PetStoreMvc.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetStoreMvc.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PetStoreMvc.Models.ApplicationDbContext";
        }

        protected override void Seed(PetStoreMvc.Models.ApplicationDbContext context)
        {
            var dogsCategory = new Category
            {
                Id = new Guid("5362fb00-d034-46dc-9485-c6703cd993e4"),
                Name = "Dogs"
            };

            var catsCategory = new Category
            {
                Id = new Guid("ed5022d7-d038-4c0b-8fdb-bef1dd042b81"),
                Name = "Cats"
            };

            var parrotsCategory = new Category
            {
                Id = new Guid("115c9e3b-e1e4-4b2d-a2f4-fe1f15d7bea8"),
                Name = "Parrots"
            };

            context.Categories.AddOrUpdate(c => c.Id,
                dogsCategory, catsCategory, parrotsCategory);

            var kennelSubCat = new SubCategory
            {
                Id = new Guid("00e76e6c-3dc5-4387-a79b-01ce00808d9f"),
                Name = "Kennels",
                CategoryId = dogsCategory.Id
            };

            var dogFoodSubCategory = new SubCategory
            {
                Id = new Guid("115c9e3b-e1e4-4b2d-a2f4-fe1f15d7bea8"),
                Name = "Food",
                CategoryId = dogsCategory.Id
            };

            var litterBoxSubCategory = new SubCategory
            {
                Id = new Guid("f40047ce-75a4-4ec4-8a70-36bcfbab6499"),
                Name = "Litter boxes",
                CategoryId = catsCategory.Id
            };

            var catFoodSubCategory = new SubCategory
            {
                Id = new Guid("c1d8b7cd-10f1-43c9-aab0-98f1380caf9a"),
                Name = "Food",
                CategoryId = catsCategory.Id
            };

            context.SubCategories.AddOrUpdate(sc => sc.Id,
                kennelSubCat, dogFoodSubCategory, litterBoxSubCategory, catFoodSubCategory);

            var catFishProduct = new Product
            {
                Id = new Guid("98ed5a3d-5f60-49f3-b91b-11ab1d0227bf"),
                Name = "Royal Fish",
                SubCategoryId = catFoodSubCategory.Id,
                Description = "Delicious fish for Mr. Cat",
                Price = 0.60m
            };

            var dogSausageProduct = new Product
            {
                Id = new Guid("b4c88059-2044-4aa9-ac20-33dd5ba98aed"),
                Name = "Royal Sausage",
                SubCategoryId = dogFoodSubCategory.Id,
                Description = "Delicious sausages",
                Price = 1.14m
            };

            context.Products.AddOrUpdate(p => p.Id,
                catFishProduct, dogSausageProduct);
        }
    }
}
