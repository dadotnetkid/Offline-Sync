using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jarcet.Mobile.Services.OfflineSyncService
{
    public class AzureOfflineSyncService : IOfflineSyncService
    {
        private AzureUnitOfWork unitOfWork = new AzureUnitOfWork();
        public async Task Pull()
        {
            await unitOfWork.ClientsRepo.DeleteAllAsync();
            await unitOfWork.QoutesRepo.DeleteAllAsync();
            await unitOfWork.QoutesRepo.PullAsync(null);
            await unitOfWork.ClientsRepo.PullAsync(null);
            await unitOfWork.ProductsRepo.PullAsync(null);
        }

        public async Task Push()
        {
            await unitOfWork.QoutesRepo.PushAsync();
            await unitOfWork.ClientsRepo.PushAsync();
        }
    }
}
