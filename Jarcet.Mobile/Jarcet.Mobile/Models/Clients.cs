using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jarcet.Mobile.Models
{
    public partial class Clients
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public short? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public short? CivilStatus { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [JsonIgnore]
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }

    }
}
