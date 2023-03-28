namespace Doanweb1.ViewModels
{
    public enum PaymentMethods : int
    {
        COD = 1,
        MOMO = 2,

    }
    public class OrderViewModel
    {
        public string FullName { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}