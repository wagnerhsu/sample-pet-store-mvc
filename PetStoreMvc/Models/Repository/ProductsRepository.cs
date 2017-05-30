using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStoreMvc.Models.Repository
{
    public class ProductsRepository
    {
        public ProductsRepository()
        {

        }

        public IEnumerable<Product> List()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Products
                    .Include(nameof(Product.SubCategory))
                    .ToList();
            }
        }

        public Product Find(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Products
                    .Include(nameof(Product.SubCategory))
                    .Single(p => p.Id == id);
            }
        }
    }
}