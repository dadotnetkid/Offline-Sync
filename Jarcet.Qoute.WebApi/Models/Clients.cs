namespace Jarcet.Qoutes.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clients()
        {
            Qoutes = new HashSet<Qoutes>();
        }

       [StringLength(255)]
        public string CategoryId { get; set; }

        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(255)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string MiddleName { get; set; }

        public short? Gender { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? BirthDate { get; set; }

        public short? CivilStatus { get; set; }

        [StringLength(255)]
        public string AddressLine1 { get; set; }

        [StringLength(255)]
        public string AddressLine2 { get; set; }

        public virtual Categories Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Qoutes> Qoutes { get; set; }
    }
}
