namespace Jarcet.Qoutes.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            QouteDetails = new HashSet<QouteDetails>();
        }

        [StringLength(255)]
        public string Id { get; set; }

        [StringLength(255)]
        public string ProductId { get; set; }

        [StringLength(255)]
        public string CategoryId { get; set; }

        [StringLength(255)]
        public string ProductName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }

        public virtual Categories Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QouteDetails> QouteDetails { get; set; }
    }
}
