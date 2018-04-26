using System;
using System.Collections.Generic;
using System.Text;

namespace Jarcet.Mobile.Models
{
   public partial class Categories
    {
        public string Id { get; set; }
        public int? Type { get; set; }
        public string CategoryName { get; set; }
        public decimal? Discount { get; set; }
    }

}
