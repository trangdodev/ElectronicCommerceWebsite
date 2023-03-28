using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Doanweb1.Models;
using Doanweb1.ViewModels;

namespace Doanweb1.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var listShoppingCart = GetShoppingCartFromSession();

            ViewBag.TotalCount = listShoppingCart.Count;
            ViewBag.Total = listShoppingCart.Sum(x => x.Money);
            ViewBag.GrandTotal = ViewBag.Total + 25000M;

            return View(listShoppingCart);
        }

        public RedirectToRouteResult AddToCart(int id)
        {
            var context = new ECommerceDbContext();
            var listShoppingCart = GetShoppingCartFromSession();
            var existProductInCart = listShoppingCart.FirstOrDefault(x => x.Id == id);

            // FACT: add totally new product to cart
            if (existProductInCart == null)
            {
                var product = context.Products.FirstOrDefault(x => x.ProductId == id);
                var cartItem = new CartItemViewModel()
                {
                    Id = id,
                    Name = product.ProductName,
                    Quantity = 1,
                    Image = product.ImageUrl,
                    Price = product.Price,
                };
                listShoppingCart.Add(cartItem);
                Session["ShoppingCart"] = listShoppingCart;
            }
            // FACT: product is existed in cart currently, only increase 1 quantity in cart
            else
            {
                existProductInCart.Quantity += 1;
            }

            return RedirectToAction("Index", "ShoppingCart");
        }

        public ActionResult GetCountItemInCart()
        {
            ViewBag.CartItemCount = GetShoppingCartFromSession().Count;

            return PartialView("_CartItemCountPartial");
        }

        private List<CartItemViewModel> GetShoppingCartFromSession()
        {
            var listShoppingCart = Session["ShoppingCart"] as List<CartItemViewModel>;
            if (listShoppingCart == null)
            {
                listShoppingCart = new List<CartItemViewModel>();
                Session["ShoppingCart"] = listShoppingCart;
            }
            return listShoppingCart;
        }
    }
}