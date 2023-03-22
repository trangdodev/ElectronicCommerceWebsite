namespace Doanweb1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Delivery")]
    public partial class Delivery
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeliveryId { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [Required]
        [StringLength(12)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        public virtual Order Order { get; set; }
    }
}
