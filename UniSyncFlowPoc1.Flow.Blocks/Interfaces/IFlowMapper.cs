using System;

namespace UniSyncFlowPoc1.Flow.BlockDefinitions
{
    public interface IFlowMapper<in T, out TY> : IDisposable
    {
        TY Map(T message);
    }
}