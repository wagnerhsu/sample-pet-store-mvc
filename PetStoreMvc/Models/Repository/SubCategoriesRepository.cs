using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStoreMvc.Models.Repository
{
    public class SubCategoriesRepository
    {
        public SubCategoriesRepository()
        {

        }

        public IEnumerable<SubCategory> List()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.SubCategories
                    .Include(nameof(SubCategory.Category))
                    .ToList();
            }
        }
    }
}