using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using Jarcet.Mobile.Services;
using Jarcet.Mobile.Models;

namespace Jarcet.Mobile.Services
{
    public class AzureUnitOfWork : IDisposable
    {
        private bool disposed;
        MobileServiceClient client;
        public AzureUnitOfWork()
        {
            //  client = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient(Constants.Constants.ApplicationUrl);
            client = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient(MobileServiceUsers.ApplicationUrl);
            if (MobileServiceUsers.mobileServiceUser != null)
            {
                client.CurrentUser = new MobileServiceUser(MobileServiceUsers.mobileServiceUser.UserId);
                client.CurrentUser.MobileServiceAuthenticationToken = MobileServiceUsers.mobileServiceUser.MobileServiceAuthenticationToken;
            }
        }


        #region Users
        private AzureRepository<Users> usersRepo;
        public AzureRepository<Users> UsersRepo
        {
            get
            {
                if (usersRepo == null)
                    usersRepo = new AzureRepository<Users>(client);
                return usersRepo;
            }
            set { usersRepo = value; }
        }
        #endregion

        private AzureRepository<Qoutes> qouteRepo;
        public AzureRepository<Qoutes> QoutesRepo
        {
            get
            {
                if (qouteRepo == null)
                    qouteRepo = new AzureRepository<Qoutes>(client);
                return qouteRepo;
            }
            set { qouteRepo = value; }
        }

        private AzureRepository<Clients> clientsRepo;
        public AzureRepository<Clients> ClientsRepo
        {
            get
            {
                if (clientsRepo == null)
                    clientsRepo = new AzureRepository<Clients>(client);
                return clientsRepo;
            }
            set { clientsRepo = value; }
        }

        private AzureRepository<Products> productsRepo;
        public AzureRepository<Products> ProductsRepo
        {
            get
            {
                if (productsRepo == null)
                    productsRepo = new AzureRepository<Products>(client);
                return productsRepo;
            }
            set { productsRepo = value; }
        }
        #region Disposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    client.Dispose();
                }
            }
            this.disposed = true;
        }

        public MobileServiceUser User
        {
            get
            {
                return client.CurrentUser;

            }
        }
        #endregion
            }
}
