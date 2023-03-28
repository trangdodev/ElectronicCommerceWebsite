using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Doanweb1.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        [DisplayName("Tên sản phẩm")]
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public decimal Money
        {
            get
            {
                return Quantity * Price;
            }
        }
    }
}