using PetStoreMvc.Models;
using PetStoreMvc.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStoreMvc.Controllers
{
    public class ProductsController : Controller
    {

        private ProductsRepository _repository = new ProductsRepository();
        private SubCategoriesRepository _subCategoriesRepository = new SubCategoriesRepository();

        // GET: Products
        public ActionResult Index()
        {
            return View(_repository.List());
        }

        public ActionResult Details(Guid id)
        {
            var product = _repository.Find(id);
            if (product != null)
            {

                IncludeSubCategoriesListItems();
                return View(product);
            }

            return HttpNotFound();
        }

        public ActionResult Create()
        {
            var product = new Product();
            IncludeSubCategoriesListItems();
            return View(product);
        }

        public ActionResult Delete(Guid id)
        {
            var product = _repository.Find(id);
            if (product != null)
            {

                IncludeSubCategoriesListItems();
                return View(product);
            }

            return HttpNotFound();
        }

        public ActionResult Edit(Guid id)
        {
            var product = _repository.Find(id);
            if (product != null)
            {

                IncludeSubCategoriesListItems();
                return View(product);
            }

            return HttpNotFound();
        }

        private void IncludeSubCategoriesListItems()
        {
            ViewData[nameof(Product.SubCategory)] = _subCategoriesRepository.List().Select(sc => new SelectListItem
            {
                Text = sc.Category.Name + " => " + sc.Name,
                Value = sc.Id.ToString()
            }).ToList();
        }
    }
}