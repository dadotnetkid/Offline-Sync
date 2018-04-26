using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jarcet.Mobile.Models
{
    public partial class Products
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? Cost { get; set; }
        public Categories Categories { get; set; }
        [JsonIgnore]
        public string ProductDetail
        {
            get { return this.ProductId + " - " + this.ProductName; }
        }
    }
}

