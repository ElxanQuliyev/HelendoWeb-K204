using HelendoWebK204.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace HelendoWebK204.ViewModels
{
    public class ShopVM
    {
        public List<Product> Products{ get; set; }
        public List<Category> Categories { get; set; }
        public int? SortBy { get; set; }
        public string searchTerm{ get; set; }
        public int? CategoryId { get; set; }
        public decimal? MaximumPrice { get; set; }
        public decimal? MinimumPrice { get; set; }
        public Pager Pager { get; set; }

    }
}