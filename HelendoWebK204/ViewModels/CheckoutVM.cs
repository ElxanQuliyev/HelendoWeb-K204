using HelendoWebK204.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelendoWebK204.ViewModels
{
    public class CheckoutVM
    {
        public List<Product> Products { get; set; }
        public List<int> ProductIDS { get; set; }
        public ApplicationUser User { get; set; }
    }
}