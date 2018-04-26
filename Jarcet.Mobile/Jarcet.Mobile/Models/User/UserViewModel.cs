using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Jarcet.Mobile.Models.User
{
    public class UserViewModel : NotifyPropertyService
    {
        private Users _users;

        public Users Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }



    }
}
