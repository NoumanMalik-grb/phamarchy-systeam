namespace phamarchy_systeam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_details = new HashSet<Order_details>();
            Order1 = new HashSet<Order>();
        }

        [Key]
        public int Order_id { get; set; }

        [StringLength(100)]
        public string User_name { get; set; }

        [StringLength(50)]
        public string Order_Type { get; set; }

        [StringLength(50)]
        public string Order_status { get; set; }

        public DateTime? Order_date_time { get; set; }

        public int? User_fid { get; set; }

        public int? Supplier_fid { get; set; }

        public int? Order_FID_Return { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_details> Order_details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order1 { get; set; }

        public virtual Order Order2 { get; set; }

        public virtual Supplier_details Supplier_details { get; set; }

        public virtual User_details User_details { get; set; }
    }
}
