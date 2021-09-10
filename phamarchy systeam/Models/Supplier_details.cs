namespace phamarchy_systeam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplier_details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier_details()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Supplier_id { get; set; }

        [StringLength(100)]
        public string Supplier_name { get; set; }

        public string Supplier_Adress { get; set; }

        [StringLength(50)]
        public string Supplier_Phone { get; set; }

        public string Company_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
