using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jarcet.Mobile.Services.OfflineSyncService
{
    public class OfflineSyncService : IOfflineSyncService
    {
        private IOfflineSyncService syncService;

        public OfflineSyncService(IOfflineSyncService syncService)
        {
            this.syncService = syncService;
        }

        public async Task Pull()
        {
            await syncService.Pull();
        }

        public async Task Push()
        {
            await syncService.Push();
        }
    }
}
