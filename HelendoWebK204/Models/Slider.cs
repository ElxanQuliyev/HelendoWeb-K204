namespace HelendoWebK204.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Slider
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(250)]
        public string Header { get; set; }

        [StringLength(250)]
        public string subHeader { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
