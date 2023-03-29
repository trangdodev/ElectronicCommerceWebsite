using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Doanweb1.Models;
using Doanweb1.ViewModels;
using PagedList;

using System.Data.Entity;
using System;

namespace Doanweb1.Controllers
{
    public class WishListController : Controller
    {
        // GET: WishList
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageIndex = page.HasValue ? page.Value : 1;

            var wishList = GetWishListFromSession();
            var db = new ECommerceDbContext();
            var wishListProductOrderedByAddedAt = wishList.OrderByDescending(x => x.AddedAt);
            var listWishProduct = new List<Product>();
            foreach (var wish in wishListProductOrderedByAddedAt)
            {
                listWishProduct.Add(db.Products.FirstOrDefault(x => x.ProductId == wish.ProductId));
            }
            var result = listWishProduct.ToPagedList(pageIndex, pageSize);

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

            return View(result);
        }

        public RedirectToRouteResult AddToWishList(int productId)
        {

            AddToWishListLogic(productId);
            return RedirectToAction("Index", "WishList");
        }

        public ActionResult GetWishListCount()
        {
            ViewBag.WishListCount = GetWishListFromSession().Count;

            return PartialView("_WishListCountPartial");
        }

        private bool AddToWishListLogic(int productId)
        {
            var wishList = GetWishListFromSession();
            if (wishList.Any(x => x.ProductId == productId))
            {
                return false;
            }
            wishList.Add(new WishListViewModel()
            {
                ProductId = productId,
                AddedAt = DateTime.Now
            });
            Session["WishList"] = wishList;
            return true;
        }

        private List<WishListViewModel> GetWishListFromSession()
        {
            var wishList = Session["WishList"] as List<WishListViewModel>;
            if (wishList == null)
            {
                wishList = new List<WishListViewModel>();
                Session["WishList"] = wishList;
            }
            return wishList;
        }
    }
}