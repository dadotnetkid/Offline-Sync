using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Jarcet.Qoutes.WebApi.Models
{
    public  class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    public partial class Users : IUser<string>
    {

    }
}