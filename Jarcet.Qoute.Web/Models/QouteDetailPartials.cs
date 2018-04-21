using Jarcet.Qoute.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarcet.Qoute.Web.Models
{
    public partial class QouteDetails
    {
        // public decimal? Total { get { return new QouteDetailsRepository(new QouteDetailsService(this))?.Total; } }
        public decimal? Total
        {
            get
            {
                var total = (this?.Products?.Cost * this?.Qty) - ((this?.Products?.Cost * this?.Qty) * ((this?.Qoutes?.Clients?.Categories?.Discount ?? 0.0M) / 100.0M));
                return total;
            }
        }
        // public decimal? Total { get => throw new NotImplementedException(); set =; }
        //     public decimal? Total => new QouteDetailsRepository(new QouteDetailsService(this)).Total;
    }
}