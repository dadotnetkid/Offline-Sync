using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace Jarcet.Models
{
    public partial class Clients : EntityData
    {
        [NotMapped]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;

            }
        }
    }
}