//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jarcet.Qoute.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Qoutes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Qoutes()
        {
            this.QouteDetails = new HashSet<QouteDetails>();
        }
    
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string Subject { get; set; }
        public Nullable<System.DateTime> DateRequested { get; set; }
        public string UserId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QouteDetails> QouteDetails { get; set; }
        public virtual Users Users { get; set; }
        public virtual Clients Clients { get; set; }
    }
}
