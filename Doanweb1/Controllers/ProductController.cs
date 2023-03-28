using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doanweb1.Models;
using PagedList;
using System.Data.Entity;

namespace Doanweb1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? page)
        {
            var context = new ECommerceDbContext();
            int pagesize = 6;
            int pageIndex = page.HasValue ? page.Value : 1;
            var result = context.Products.ToList().ToPagedList(pageIndex, pagesize);

            var category = context.Categories.ToList();
            //var brand = context.Brands.Include(x => x.Products).Select(x => new BrandWithCount()
            //{
            //    BrandId = x.Id,

            //}).ToList();

            //ViewBag.brand = brand;
            ViewBag.Category = category;
            return View(result);
        }

        public ActionResult ProductDetail(int id)
        {
            var db = new ECommerceDbContext();
            var products = db.Products.Include("ProductDetails").FirstOrDefault(x => x.ProductId == id);
            return View(products);

        }
    }
}