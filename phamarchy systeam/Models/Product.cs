namespace phamarchy_systeam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Order_details = new HashSet<Order_details>();
        }

        [Key]
        public int Product_id { get; set; }

        [Required]
        [StringLength(100)]
        public string Product_name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Product_Sale_price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Product_Purchase_price { get; set; }
        [NotMapped]
        public int quantity { get; set; }   
        [NotMapped]
        public int Rquantity { get; set; }
        [Required]
        public string Product_packing_siza { get; set; }

        [Required]
        [StringLength(50)]
        public string Product_status { get; set; }

        [Column(TypeName = "date")]
        public DateTime Product_Exp_date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Product_discount { get; set; }

        [StringLength(100)]
        public string Product_Batch_no { get; set; }

        public int Category_fid { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_details> Order_details { get; set; }
    }
}
