using Microsoft.Azure.Mobile.Server;

namespace Jarcet.Qoutes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QouteDetails : EntityData
    {
        [StringLength(255)]
        public string QouteId { get; set; }

        [StringLength(255)]
        public string ProductId { get; set; }

        public int? Qty { get; set; }

        public virtual Products Products { get; set; }

        public virtual Qoutes Qoutes { get; set; }
    }
}
