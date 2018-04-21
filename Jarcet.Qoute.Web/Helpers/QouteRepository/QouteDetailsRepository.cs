using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarcet.Qoute.Web.Helpers
{
    public class QouteDetailsRepository : IQouteDetailsService
    {
        private IQouteDetailsService qouteDetailsService;

        public QouteDetailsRepository(IQouteDetailsService qouteDetailsService)
        {
            this.qouteDetailsService = qouteDetailsService;
        }

        public decimal? Total => this.Total;
    }
}