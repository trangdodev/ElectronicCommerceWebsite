using System;

namespace Doanweb1.ViewModels
{
    public class WishListViewModel
    {
        public int ProductId { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.Now;
    }
}