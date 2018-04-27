using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Jarcet.Mobile.Annotations;

namespace Jarcet.Mobile.Models
{
    public class NotifyPropertyService : INotifyPropertyChanged
    {
        private bool _isRefreshing = true;
        private bool _isEnable;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsEnable
        {
            get => _isEnable;
            set { _isEnable = value; OnPropertyChanged(); }

        }
        public bool IsRefreshing
        {
            get => _isRefreshing; set
            {
                _isRefreshing = value;
                this.OnPropertyChanged();
            }

        }
    }
}
