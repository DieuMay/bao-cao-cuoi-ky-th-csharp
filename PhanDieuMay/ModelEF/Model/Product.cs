namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public decimal? UnitCost { get; set; }

        public int? Quantity { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public int? Category_Id { get; set; }

        public virtual Category Category { get; set; }
    }
}
