using PetStoreMvc.Models.Repository;
using PetStoreMvc.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStoreMvc.Controllers
{
    public class MenuController : Controller
    {
        CategoriesRepository _categoriesRepository = new CategoriesRepository();

        // GET: Menu
        public PartialViewResult Index()
        {
            var menuItems = _categoriesRepository.List()
                .Select(c => new MenuItem
                {
                    Category = c
                });
            return PartialView(menuItems);
        }
    }
}