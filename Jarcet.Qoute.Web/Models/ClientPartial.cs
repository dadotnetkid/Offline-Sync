using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarcet.Qoute.Web.Models
{
    public partial class Clients
    {
        public string ClientName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}