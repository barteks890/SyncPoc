using UniSyncFlowPoc1.Flow.BlockDefinitions;

namespace UniSyncFlowPoc1.Synchronizer.Core.FlowLogic
{
    public class SyncFlowMapper<T, TY> : IFlowMapper<T, TY>
        where T : ISyncContext
        where TY : ISyncContext
    {
        private readonly ISyncMapper<T, TY> _syncMapper;

        public SyncFlowMapper(ISyncMapper<T, TY> syncMapper)
        {
            _syncMapper = syncMapper;
        }

        public TY Map(T message)
        {
            return _syncMapper.Map(message);
        }

        public void Dispose()
        {
        }
    }
}