namespace Jarcet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            Qoutes = new HashSet<Qoutes>();
            UserClaims = new HashSet<UserClaims>();
            UserLogins = new HashSet<UserLogins>();
            UserRoles = new HashSet<UserRoles>();
        }

        public string Id { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        public bool? EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        [StringLength(25)]
        public string PhoneNumber { get; set; }

        public bool? PhoneNumberConfirmed { get; set; }

        public bool? TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool? LockoutEnabled { get; set; }

        public int? AccessFailedCount { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(150)]
        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdated { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(12)]
        public string CivilStatus { get; set; }

        [StringLength(6)]
        public string Gender { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? BirthDate { get; set; }

        [StringLength(500)]
        public string AddressLine2 { get; set; }

        [StringLength(500)]
        public string AddressLine1 { get; set; }

        public int? TownCity { get; set; }

        [StringLength(25)]
        public string Cellular { get; set; }

        public decimal? Height { get; set; }

        public decimal? Weight { get; set; }

        [StringLength(50)]
        public string Religion { get; set; }

        [StringLength(50)]
        public string Citizenship { get; set; }

        public string Languages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Qoutes> Qoutes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserClaims> UserClaims { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLogins> UserLogins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
