using PetStoreMvc.Models;
using PetStoreMvc.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult Details(Guid? id)
        {
            var product = id.HasValue ? _repository.Find(id.Value) : null;
            if (product != null)
            {
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                Product created = _repository.Create(product);

                return RedirectToAction("Details", new { id = created.Id });
            }

            IncludeSubCategoriesListItems();
            return View(product);
        }

        public ActionResult Delete(Guid? id)
        {
            var product = id.HasValue ? _repository.Find(id.Value) : null;
            if (product != null)
            {

                IncludeSubCategoriesListItems();
                return View(product);
            }

            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            try
            {
                _repository.Delete(product.Id);
                return RedirectToAction(nameof(Index));
            }
            catch (ProductNotFoundException)
            {
                return HttpNotFound();
            }
        }

        public ActionResult Edit(Guid? id)
        {
            var product = id.HasValue ? _repository.Find(id.Value) : null;
            if (product != null)
            {
                IncludeSubCategoriesListItems();
                return View(product);
            }

            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(product);
                return RedirectToAction(nameof(Details), new { id = product.Id });
            }

            return View(product);
        }

        private void IncludeSubCategoriesListItems()
        {
            ViewData[nameof(Product.SubCategoryId)] = _subCategoriesRepository.List().Select(sc => new SelectListItem
            {
                Text = sc.Category.Name + " => " + sc.Name,
                Value = sc.Id.ToString()
            }).ToList();
        }
    }
}