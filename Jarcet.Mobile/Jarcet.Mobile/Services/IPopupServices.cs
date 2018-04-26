using System;
using System.Collections.Generic;
using System.Text;

namespace Jarcet.Mobile.Services
{
   public interface IPopupServices
   {
       void ShowToast(string message,int duration);
       void ShowSnackBar(string message, int duration);
   }
}
