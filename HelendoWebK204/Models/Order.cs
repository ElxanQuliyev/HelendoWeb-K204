using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelendoWebK204.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}