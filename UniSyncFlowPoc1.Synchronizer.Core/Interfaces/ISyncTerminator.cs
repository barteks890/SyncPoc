using System.Threading.Tasks;

namespace UniSyncFlowPoc1.Synchronizer.Core
{
    public interface ISyncTerminator<T>
    {
        Task<T> TerminateFlow(T context);
    }
}