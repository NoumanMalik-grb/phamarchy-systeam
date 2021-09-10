namespace phamarchy_systeam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Phamarcy_adress
    {
        [Key]
        public int Company_id { get; set; }

        public string Company_name { get; set; }

        public string Company_adress { get; set; }

        [StringLength(50)]
        public string Company_Phone { get; set; }

        public string Company_emails { get; set; }

        [StringLength(200)]
        public string Company_licinces { get; set; }

        public string Company_logo { get; set; }
    }
}
