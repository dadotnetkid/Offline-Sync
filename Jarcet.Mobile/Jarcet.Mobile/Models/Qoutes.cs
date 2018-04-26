using System;
using System.Collections.Generic;
using System.Text;

namespace Jarcet.Mobile.Models
{
    public partial class Qoutes
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string UserId { get; set; }
        public string Subject { get; set; }
        public DateTime? DateRequested { get; set; }
        public Clients Clients { get; set; }
        public ICollection<QouteDetails> QouteDetails { get; set; }
    }
}
