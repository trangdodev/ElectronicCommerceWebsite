using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doanweb1.Models
{
    public class BrandWithCount : Brand
    {
        public int CountProduct { get; set; }
    }
}