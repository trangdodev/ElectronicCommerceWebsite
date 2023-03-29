using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Doanweb1.Models;

namespace Doanweb1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ECommerceDbContext();
            // GET 10 product which sell best to be San pham noi bat
            var bestSellProducts = db.Products.Include(x => x.OrderDetails).OrderBy(x => x.OrderDetails.Count()).Take(10).ToList();
            ViewBag.BestSellProducts = bestSellProducts;

            var category = db.Categories.ToList();
            ViewBag.Category = category;
            return View();
        }

        public ActionResult Layout()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}