using System.Linq;
using System.Web.Mvc;
using Doanweb1.Models;
using PagedList;
using System.Data.Entity;
using Doanweb1.ViewModels;

namespace Doanweb1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? page, int? categoryId, string brand = null, string productName = null, string sortOrder = null, string priceFilter = null)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentSearch = productName;
            ViewBag.CurrentFilter = priceFilter;

            var context = new ECommerceDbContext();
            int pagesize = 6;
            int pageIndex = page.HasValue ? page.Value : 1;
            IQueryable<Product> query = context.Products;

            if (!string.IsNullOrEmpty(productName))
            {
                query = query.Where(x => x.ProductName.Contains(productName));
            }
            if (categoryId != null)
            {
                query = query.Where(x => x.CategoryId == categoryId);
            }
            if (!string.IsNullOrEmpty(brand))
            {
                query = query.Include(x => x.Brand).Where(x => x.Brand.BrandName.Contains(brand));
            }

            switch (sortOrder)
            {
                case "price_desc":
                    query = query.OrderByDescending(s => s.Price);
                    break;
                case "rating":
                    query = query.OrderBy(s => s.Rating);
                    break;
                case "rating_desc":
                    query = query.OrderByDescending(s => s.Rating);
                    break;
                default:
                    query = query.OrderBy(s => s.Price);
                    break;
            }

            switch (priceFilter)
            {
                case "1": { query = query.Where(x => x.Price <= 5000000M); break; }
                case "2": { query = query.Where(x => x.Price >= 5000000M && x.Price <= 10000000M); break; }
                case "3": { query = query.Where(x => x.Price >= 10000000M && x.Price <= 50000000M); break; }
                case "4": { query = query.Where(x => x.Price >= 50000000M); break; }
                default: break;
            }

            var result = query.ToPagedList(pageIndex, pagesize);

            var category = context.Categories.ToList();

            var brands = context.Brands.Include(x => x.Products).Select(x => new BrandWithCountViewModel()
            {
                BrandId = x.BrandId,
                BrandName = x.BrandName,
                LogoUrl = x.LogoUrl,
                ProductCount = x.Products.Count,
            }).ToList();

            ViewBag.brand = brands;
            ViewBag.Category = category;
            return View(result);
        }

        public ActionResult ProductDetail(int id)
        {
            var db = new ECommerceDbContext();
            var products = db.Products.FirstOrDefault(x => x.ProductId == id);

            var category = db.Categories.ToList();

            var brands = db.Brands.Include(x => x.Products).Select(x => new BrandWithCountViewModel()
            {
                BrandId = x.BrandId,
                BrandName = x.BrandName,
                LogoUrl = x.LogoUrl,
                ProductCount = x.Products.Count,
            }).ToList();

            ViewBag.brand = brands;
            ViewBag.Category = category;
            return View(products);

        }

    }
}