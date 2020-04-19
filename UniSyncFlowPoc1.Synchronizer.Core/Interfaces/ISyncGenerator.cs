using System.Threading.Tasks;

namespace UniSyncFlowPoc1.Synchronizer.Core
{
    public interface ISyncGenerator<T>
    {
        Task<T> GenerateMessageAsync();
    }
}