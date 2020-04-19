using System.Threading.Tasks;
using UniSyncFlowPoc1.Flow.BlockDefinitions;

namespace UniSyncFlowPoc1.Synchronizer.Core.FlowLogic
{
    public class SyncFlowTerminator<T> : IFlowTerminator<T>
        where T : ISyncContext
    {
        private readonly ISyncTerminator<T> _syncTerminator;

        public SyncFlowTerminator(ISyncTerminator<T> syncTerminator)
        {
            _syncTerminator = syncTerminator;
        }

        public async Task<T> TerminateFlow(T message)
        {
            return await _syncTerminator.TerminateFlow(message);
        }

        public void Dispose()
        {
        }
    }
}