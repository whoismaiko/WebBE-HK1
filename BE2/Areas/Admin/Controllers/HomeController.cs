using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE2.Models;
using BE2.Models.ViewModel;
using PagedList;
using PagedList.Mvc;


namespace BE2.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();
        // GET: Admin/Home
        public ActionResult Index(string searchTerm, int? page)
        {
            var model = new HomeProductVM();
            var products = db.Products.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                model.SearchTerm = searchTerm;
                products = products.Where(p => p.ProductName.Contains(searchTerm) ||
                    p.ProductDecription.Contains(searchTerm) ||
                    p.Category.CategoryName.Contains(searchTerm));
            }

            int pageNumber = page ?? 1;
            int pageSize = 6;

            model.FeaturedProducts = products.OrderByDescending(p => p.OrderDetails.Count()).Take(10).ToList();

            model.NewProducts = products.OrderBy(p => p.OrderDetails.Count()).Take(20).ToPagedList(pageNumber, pageSize);


            return View(model);
        }
    }
}