namespace Jarcet.Qoutes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Qoutes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Qoutes()
        {
            QouteDetails = new HashSet<QouteDetails>();
        }

    

        [StringLength(255)]
        public string ClientId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        [StringLength(255)]
        public string Subject { get; set; }

        public DateTime? DateRequested { get; set; }


        public virtual Clients Clients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QouteDetails> QouteDetails { get; set; }

        public virtual Users Users { get; set; }
    }
}
