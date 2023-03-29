using System.ComponentModel;

namespace Doanweb1.ViewModels
{
    public class CartItemViewModel
    {
        public int ProductId { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }
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