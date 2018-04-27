using System.Threading.Tasks;

namespace Jarcet.Mobile.Services.OfflineSyncService
{
    public interface IOfflineSyncService
    {
        Task Pull();
        Task Push();
    }
}