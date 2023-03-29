using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Doanweb1.Models;
using Doanweb1.ViewModels;
using System.Data.Entity;
using System.Net;

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
            ViewBag.OrderError = Session["Order_Error"];
            Session["Order_Error"] = null;
            return View(listShoppingCart);
        }

        public RedirectToRouteResult AddToCart(int id, int? quantity)
        {

            AddToCardLogic(id, quantity ?? 1);
            return RedirectToAction("Index", "ShoppingCart");
        }

        [HttpPost]
        public ActionResult AddToCart(AddToCardRequestViewModel addToCard)
        {
            if (!AddToCardLogic(addToCard.ProductId, addToCard.Quantity))
            {
                return Json(new { success = false });
            }

            var cartItemCount = GetShoppingCartFromSession().Sum(x => x.Quantity);

            return Json(new { success = true, cartItemCount }); ;
        }

        private bool AddToCardLogic(int id, int quantity)
        {
            var context = new ECommerceDbContext();
            var listShoppingCart = GetShoppingCartFromSession();

            var existProductInCart = listShoppingCart.FirstOrDefault(x => x.ProductId == id);

            var product = context.Products.FirstOrDefault(x => x.ProductId == id);

            if ((existProductInCart?.Quantity ?? 0 + quantity) > product.Quantity)
            {
                return false;
            }
            // FACT: add totally new product to cart
            if (existProductInCart == null)
            {
                var cartItem = new CartItemViewModel()
                {
                    ProductId = id,
                    Name = product.ProductName,
                    Quantity = quantity,
                    Image = product.ImageUrl,
                    Price = product.Price,
                };
                listShoppingCart.Add(cartItem);
                Session["ShoppingCart"] = listShoppingCart;
            }
            // FACT: product is existed in cart currently, only increase 1 quantity in cart
            else
            {
                existProductInCart.Quantity += quantity;
            }
            return true;
        }

        public ActionResult GetCountItemInCart()
        {
            ViewBag.CartItemCount = GetShoppingCartFromSession().Sum(x => x.Quantity);

            return PartialView("_CartItemCountPartial");
        }


        [HttpPost]
        public RedirectToRouteResult Order(OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("<br/>", ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToList());
                Session["Order_Error"] = errors;
                return RedirectToAction("Index");
            }
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
                ProductId = cartItem.ProductId,
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