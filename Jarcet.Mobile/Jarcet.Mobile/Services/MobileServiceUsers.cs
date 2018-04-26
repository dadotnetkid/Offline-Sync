using Jarcet.Mobile.Models;
using Microsoft.WindowsAzure.MobileServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;

namespace Jarcet.Mobile.Services
{
    public static class MobileServiceUsers
    {
       public static string ApplicationUrl = @"http://192.168.254.102:53197/";
        //public static string ApplicationUrl = @"http://192.168.254.102:50782";
        public static string offlineDbPath = @"localstore.db";
        public static MobileServiceUser mobileServiceUser { get; set; }

        public static async Task<bool> LoginUserAsync(Users users)
        {
            AzureUnitOfWork unitOfWork = new AzureUnitOfWork();
            mobileServiceUser = await unitOfWork.UsersRepo.LoginAsync(users.UserName, users.Password);
            if (mobileServiceUser != null)
            {
                Account account = new Account(users.UserName);
                account.Properties.Add("UserId", mobileServiceUser.UserId);
                account.Properties.Add("Token", mobileServiceUser.MobileServiceAuthenticationToken);
                AccountStore.Create().Save(account, "NorthOps");
                return true;
            }
            else
                return false;
        }



        public static bool GetCredentials()
        {
            var account = AccountStore.Create().FindAccountsForService("NorthOps").FirstOrDefault();
            if (account != null)
            {
                mobileServiceUser = new MobileServiceUser(account.Properties["UserId"]);
                mobileServiceUser.MobileServiceAuthenticationToken = account.Properties["Token"];
                return true;
            }

            return false;
        }
        public static void Logout()
        {
            var account = AccountStore.Create().FindAccountsForService("NorthOps").FirstOrDefault();
            if (account != null)
            {
                AccountStore.Create().Delete(account, "NorthOps");
            }
        }

    }
}

