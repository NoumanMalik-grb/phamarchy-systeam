namespace phamarchy_systeam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_details
    {
        [Key]
        public int Od_id { get; set; }

        public int Order_fid { get; set; }

        public int Product_fid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Product_sale_price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Product_purchase_price { get; set; }

        public int Product_qlty { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
