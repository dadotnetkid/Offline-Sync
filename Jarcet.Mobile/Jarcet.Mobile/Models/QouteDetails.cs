using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jarcet.Mobile.Models
{
    public partial class QouteDetails
    {
        public string Id { get; set; }
        public string QouteId { get; set; }
        public string ProductId { get; set; }
        public int? Qty { get; set; }

        public Qoutes Qoutes { get; set; }
        public Products Products { get; set; }
        [JsonIgnore]
        public decimal? Total
        {
            get { return (this.Qty ?? 1) * this.Products.Cost; }
        }

    }
}
