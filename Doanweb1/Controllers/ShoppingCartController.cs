using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Doanweb1.Models;
using Doanweb1.ViewModels;
using System.Data.Entity;

namespace Doanweb1.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var listShoppingCart = GetShoppingCartFromSession();

            ViewBag.TotalCount = listShoppingCart.Sum(x => x.Quantity);
            ViewBag.Total = listShoppingCart.Sum(x => x.Money);
            ViewBag.GrandTotal = ViewBag.Total + 25000M;

            return View(listShoppingCart);
        }

        public RedirectToRouteResult AddToCart(int id, int? detailId)
        {
            var context = new ECommerceDbContext();
            var listShoppingCart = GetShoppingCartFromSession();
            if (detailId == null)
            {
                detailId = context.Products.Include(x => x.ProductDetails).FirstOrDefault(x => x.ProductId == id).ProductDetails.FirstOrDefault()?.ProductDetailId;
            }
            var existProductInCart = listShoppingCart.FirstOrDefault(x => x.ProductId == id && x.ProductDetailId == detailId);

            // FACT: add totally new product to cart
            if (existProductInCart == null)
            {
                var product = context.Products.Include(x => x.ProductDetails).FirstOrDefault(x => x.ProductId == id);
                var cartItem = new CartItemViewModel()
                {
                    ProductId = id,
                    ProductDetailId = detailId,
                    Name = product.ProductName,
                    Quantity = 1,
                    Image = product.ImageUrl,
                    Price = product.Price + product.ProductDetails.FirstOrDefault()?.VariantPrice ?? 0,
                    Variant = product.ProductDetails.FirstOrDefault()?.Variant
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


        [HttpPost]
        public RedirectToRouteResult Order(OrderViewModel orderViewModel)
        {
            var listCardItems = GetShoppingCartFromSession();
            var order = new Order()
            {
                IsComplete = false,
                IsPaid = false,
                TransactionId = null,
                OrderDate = new System.DateTime()
            };
            var delivery = new Delivery()
            {
                DeliveryDate = System.DateTime.Now,
                Address = orderViewModel.Address,
                PhoneNumber = orderViewModel.Phone,
                CustomerName = orderViewModel.FullName,
            };

            order.Delivery = delivery;

            var db = new ECommerceDbContext();
            db.Orders.Add(order);
            db.SaveChanges();

            var listOrderDetail = listCardItems.Select(cartItem => new OrderDetail()
            {
                OrderId = order.OrderId,
                ProductDetailId = cartItem.ProductId,
                Price = cartItem.Price,
                Quantity = cartItem.Quantity,
            });

            db.OrderDetails.AddRange(listOrderDetail);
            db.SaveChanges();
            Session["ShoppingCart"] = new List<CartItemViewModel>();

            return RedirectToAction("GetOrderSuccessfully");
        }

        public ActionResult GetOrderSuccessfully()
        {
            return View();
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