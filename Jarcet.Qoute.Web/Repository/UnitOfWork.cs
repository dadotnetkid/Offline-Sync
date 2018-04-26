using Jarcet.Qoute.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Jarcet.Qoute.Web.Repository
{
    public class UnitOfWork : IDisposable
    {
        private QoutesEntities context = new QoutesEntities();

        private GenericRepository<Qoutes> qoutesRepo;
        public GenericRepository<Qoutes> QoutesRepo
        {
            get
            {
                if (this.qoutesRepo == null)
                    this.qoutesRepo = new GenericRepository<Qoutes>(context);
                return qoutesRepo;
            }
            set { qoutesRepo = value; }
        }

        private GenericRepository<Clients> clientsRepo;
        public GenericRepository<Clients> ClientsRepo
        {
            get
            {
                if (this.clientsRepo == null)
                    this.clientsRepo = new GenericRepository<Clients>(context);
                return clientsRepo;
            }
            set { clientsRepo = value; }
        }


        private GenericRepository<QouteDetails> qouteDetailsRepo;
        public GenericRepository<QouteDetails> QouteDetailsRepo
        {
            get
            {
                if (this.qouteDetailsRepo == null)
                    this.qouteDetailsRepo = new GenericRepository<QouteDetails>(context);
                return qouteDetailsRepo;
            }
            set { qouteDetailsRepo = value; }
        }


        private GenericRepository<Products> productsRepo;
        public GenericRepository<Products> ProductsRepo
        {
            get
            {
                if (this.productsRepo == null)
                    this.productsRepo = new GenericRepository<Products>(context);
                return productsRepo;
            }
            set { productsRepo = value; }
        }

        private GenericRepository<Categories> categoryRepo;
        public GenericRepository<Categories> CategoriesRepo
        {
            get
            {
                if (this.categoryRepo == null)
                    this.categoryRepo = new GenericRepository<Categories>(context);
                return categoryRepo;
            }
            set { categoryRepo = value; }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}