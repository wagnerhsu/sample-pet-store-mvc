using PetStoreMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStoreMvc.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            IEnumerable<Product> products;
            using (var db = new ApplicationDbContext())
            {
                products = db.Products.Include(nameof(Product.SubCategory)).ToList();
            }
            return View(products);
        }

        public ActionResult Details(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                IncludeSubCategoriesListItems(db);
                return View(db.Products.Include(nameof(Product.SubCategory)).First(p => p.Id == id));
            }
        }

        public ActionResult Create()
        {
            var product = new Product();
            using (var db = new ApplicationDbContext())
            {
                IncludeSubCategoriesListItems(db);
            }
            return View(product);
        }

        public ActionResult Delete(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                return View(db.Products.Include(nameof(Product.SubCategory)).First(p => p.Id == id));
            }
        }

        public ActionResult Edit(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                IncludeSubCategoriesListItems(db);
                return View(db.Products.Include(nameof(Product.SubCategory)).First(p => p.Id == id));
            }
        }

        private void IncludeSubCategoriesListItems(ApplicationDbContext db)
        {
            var groups = db.Categories.Select(c => new SelectListGroup { Name = c.Name }).ToList();

            ViewData[nameof(Product.SubCategory)] = db.SubCategories.Select(sc => new SelectListItem
            {
                Text = sc.Category.Name + " => " + sc.Name,
                Value = sc.Id.ToString()
            }).ToList();
        }
    }
}