namespace phamarchy_systeam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_details()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int User_id { get; set; }

        [Required]
        [StringLength(100)]
        public string User_name { get; set; }

        [Required]
        [StringLength(100)]
        public string User_email { get; set; }

        [Required]
        [StringLength(100)]
        public string User_password { get; set; }

        [Required]
        [StringLength(100)]
        public string User_type { get; set; }

        [Required]
        [StringLength(100)]
        public string User_working_time { get; set; }

        [Required]
        [StringLength(50)]
        public string User_phone { get; set; }

        [Required]
        public string User_adress { get; set; }

        [Required]
        public string User_salary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
