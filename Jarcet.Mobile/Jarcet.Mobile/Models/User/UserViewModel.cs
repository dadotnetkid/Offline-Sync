using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Jarcet.Mobile.Models.User
{
    public class UserViewModel : NotifyPropertyService
    {
        private string _userName;
        private string _password;

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
                if (!string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.Password))
                {
                    this.IsEnable = true;
                }
                else
                {
                    this.IsEnable = false;
                }
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
                if (!string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.Password))
                {
                    this.IsEnable = true;
                }
                else
                {
                    this.IsEnable = false;
                }
            }
        }


    }
}
