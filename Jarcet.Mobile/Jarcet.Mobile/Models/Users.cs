using System;
using System.Collections.Generic;
using System.Text;

namespace Jarcet.Mobile.Models
{
    public partial class Users : NotifyPropertyService
    {
        private string _userName;
        private string _password;

        public string Id { get; set; }
        public string Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool? PhoneNumberConfirmed { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool? LockoutEnabled { get; set; }
        public int? AccessFailedCount { get; set; }
        public string UserName
        {
            get => _userName; set
            {
                _userName = value;
                this.OnPropertyChanged();
            }
        }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string CivilStatus { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine1 { get; set; }
        public int? TownCity { get; set; }
        public string Cellular { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public string Religion { get; set; }
        public string Citizenship { get; set; }
        public string Languages { get; set; }
        public string Password
        {
            get => _password; set
            {
                _password = value;
                this.OnPropertyChanged();
            }
        }
    }
}
