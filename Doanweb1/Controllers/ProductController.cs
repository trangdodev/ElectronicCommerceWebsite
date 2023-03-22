using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doanweb1.Models;

namespace Doanweb1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var db = new ECommerceDbContext();
            var products = db.Products.ToList();
            return View(products);
        }

        public ActionResult ProductDetail(int id)
        {
            var db = new ECommerceDbContext();
            var products = db.Products.Include("ProductDetails").FirstOrDefault(x => x.ProductId == id);
            return View(products);

        }
    }
}