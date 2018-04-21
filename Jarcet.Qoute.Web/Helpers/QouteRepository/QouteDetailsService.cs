using Jarcet.Qoute.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarcet.Qoute.Web.Helpers
{
    public class QouteDetailsService : IQouteDetailsService
    {
        private QouteDetails qouteDetails;

        public QouteDetailsService(QouteDetails qouteDetails)
        {
            this.qouteDetails = qouteDetails;
        }
        public decimal? Total
        {
            get
            {
                return (qouteDetails?.Products?.Cost * qouteDetails?.Qty) * qouteDetails?.Qoutes?.Clients?.Categories?.Discount;
            }
        }
    }
}