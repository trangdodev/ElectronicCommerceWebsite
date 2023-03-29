using System.ComponentModel.DataAnnotations;

namespace Doanweb1.ViewModels
{
    public enum PaymentMethods : int
    {
        COD = 1,
        MOMO = 2,

    }
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Tên là bắt buộc")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Phương thức thanh toán là bắt buộc")]
        public PaymentMethods PaymentMethod { get; set; }
        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        public string Address { get; set; }

    }
}