using System;
using System.Threading.Tasks;
using UniSyncFlowPoc1.Flow.BlockDefinitions;

namespace UniSyncFlowPoc1.Synchronizer.Core.FlowLogic
{
    public class SyncFlowGenerator<T> : IFlowGenerator<T>
         where T : ISyncContext
    {
        private readonly ISyncGenerator<T> _syncGenerator;

        public SyncFlowGenerator(ISyncGenerator<T> syncGenerator)
        {
            _syncGenerator = syncGenerator;
        }

        public async Task<T> GenerateMessageAsync()
        {
            return await _syncGenerator.GenerateMessageAsync();
        }

        public void PostProcess(T message)
        {
        }

        public void OnError(T message, Exception exception)
        {
        }

        public void Dispose()
        {
        }
    }
}
