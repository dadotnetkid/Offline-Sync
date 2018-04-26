#define OFFLINE_SYNC_ENABLED

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jarcet.Mobile.Models;
using Microsoft.WindowsAzure.MobileServices;
//using Microsoft.WindowsAzure.MobileServices;

#if OFFLINE_SYNC_ENABLED
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
#endif
namespace Jarcet.Mobile.Services
{
    public class AzureRepository<TEntity> where TEntity : class
    {

        #region offline sync
        MobileServiceClient client;
        const string offlineDbPath = @"localdb.db";
#if OFFLINE_SYNC_ENABLED
        IMobileServiceSyncTable<TEntity> tEntity;
#else
        IMobileServiceTable<TEntity> tEntity;
#endif
        #endregion

        //Constructor
        public AzureRepository(MobileServiceClient client)
        {
            this.client = client;//new MobileServiceClient(Constants.Constants.ApplicationUrl);
#if OFFLINE_SYNC_ENABLED
            var store = new MobileServiceSQLiteStore(offlineDbPath);
            store.DefineTable<TEntity>();
            //Initializes the SyncContext using the default IMobileServiceSyncHandler.
            this.client.SyncContext.InitializeAsync(store);

            this.tEntity = client.GetSyncTable<TEntity>();
#else
            this.tEntity = client.GetTable<TEntity>();
#endif
        }
        public async Task AddAsync(TEntity entity)
        {
            await tEntity.InsertAsync(entity);

        }
        public async Task AddAsync(JObject entity)
        {
            await tEntity.InsertAsync(entity);

        }
        public async Task UpdateAsync(TEntity entity)
        {
            await tEntity.UpdateAsync(entity);
        }
        public async Task DeleteAsync(Expression<Func<TEntity, bool>> Filter)
        {
            try
            {
                var entity = await tEntity.Where(Filter).ToEnumerableAsync();
                await tEntity.DeleteAsync(entity.FirstOrDefault());
            }
            catch (Exception)
            {


            }

        }

        public async Task PurgeAsync(Expression<Func<TEntity, bool>> Filter)
        {
            try
            {
                var tableQuery = tEntity.CreateQuery().Where(Filter);

                await tEntity.PurgeAsync($"purge_{tEntity.TableName}", tableQuery, true, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
        public async Task DeleteAllAsync()
        {
            await tEntity.PurgeAsync(true);
        }
        public async Task DeleteAsync(TEntity entity)
        {
            try
            {
                await tEntity.DeleteAsync(entity);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> Filter = null)
        {

            try
            {
                var res = (await tEntity.Where(Filter).ToEnumerableAsync()).ToList().FirstOrDefault();

                return res;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return null;
            }


        }
        public async Task<TEntity> FindAsync(string Id)
        {


            try
            {
                return await tEntity.LookupAsync(Id);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return null;
            }
        }
        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {

                IEnumerable<TEntity> items = await tEntity.ToEnumerableAsync();
                if (filter != null)
                    items = await tEntity.Where(filter).ToEnumerableAsync();

                return items;
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
                await Application.Current.MainPage.DisplayAlert("Error", e.Message, "Ok");
            }
            //await this.SyncAsync();
            return null;
        }

        public async Task SyncAsync(string query = "")
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await this.client.SyncContext.PushAsync();

                await this.tEntity.PullAsync(
                //The first parameter is a query name that is used internally by the client SDK to implement incremental sync.
                //Use a different query name for each unique query in your program
                query, this.tEntity.CreateQuery());
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                {
                    syncErrors = exc.PushResult.Errors;
                }
            }

            // Simple error/conflict handling. A real application would handle the various errors like network conditions,
            // server conflicts and others via the IMobileServiceSyncHandler.
            if (syncErrors != null)
            {
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        //Update failed, reverting to server's copy.
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        // Discard local change.
                        await error.CancelAndDiscardItemAsync();
                    }

                    Debug.WriteLine(@"Error executing sync operation. Item: {0} ({1}). Operation discarded.", error.TableName, error.Item["id"]);
                }
            }
        }


        public async Task PullAsync(string query = "", Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                var ret = this.tEntity.CreateQuery();

                if (filter != null)
                    await this.tEntity.PullAsync(query == "" ? $"GetAll{tEntity.TableName}" : query, ret.Where(filter), new PullOptions()
                    {
                        MaxPageSize = 10
                    });
                else
                    await this.tEntity.PullAsync(query == "" ? $"GetAll{tEntity.TableName}" : query, ret);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
        public async Task PushAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await this.client.SyncContext.PushAsync();
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                {
                    syncErrors = exc.PushResult.Errors;
                }
            }


            if (syncErrors != null)
            {
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        await error.CancelAndDiscardItemAsync();
                    }

                    Debug.WriteLine(@"Error executing sync operation. Item: {0} ({1}). Operation discarded.", error.TableName, error.Item["id"]);
                }
            }
        }

        #region User Identity
        public async Task<MobileServiceUser> LoginAsync(string UserName, string Password)
        {
            try
            {
                var token = new JObject()
                {
                    ["UserName"] = UserName,
                    ["Password"] = Password
                };
                var res = await client.LoginAsync("custom", JObject.FromObject(new Users() { UserName = UserName, Password = Password }));

                return res;
            }
            catch (Exception ex)
            {

                Debug.Write(ex.Message);
                return null;
            }

        }
        public async Task<MobileServiceUser> LoginAsync(Users users)
        {
            try
            {
                return await client.LoginAsync("token", JObject.FromObject(users));
            }
            catch (Exception ex)
            {

                Debug.Write(ex.Message);
                return null;
            }

        }
        #endregion


    }


}
