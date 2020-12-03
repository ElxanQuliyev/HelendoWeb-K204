using HelendoWebK204.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelendoWebK204.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Product>Products{ get; set; }
        public Product Product { get; set; }
        public IEnumerable<Product> FeaturedProducts { get; set; }
    }
}