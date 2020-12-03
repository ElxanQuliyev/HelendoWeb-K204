namespace HelendoWebK204.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Discount { get; set; }

        public decimal Price { get; set; }
        public string Notes{ get; set; }


        public int? categoryID { get; set; }

        public int? SKU { get; set; }

        public bool ISDeleted { get; set; }

        public bool IsActive { get; set; }

        public bool IsFeatured { get; set; }

        public int? Barcode { get; set; }

        [StringLength(200)]
        public string Supplier { get; set; }

        public int InStok { get; set; }

        public virtual Category Category { get; set; }
    }
}
