using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Jarcet.Models
{
    public  class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    public partial class Users : IUser<string>
    {
        [NotMapped]
        public string FullName {
            get { return this.FirstName + " " + this.LastName; }
        }
    }
}