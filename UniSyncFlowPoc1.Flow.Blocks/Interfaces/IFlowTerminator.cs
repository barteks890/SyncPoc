using System;
using System.Threading.Tasks;

namespace UniSyncFlowPoc1.Flow.BlockDefinitions
{
    public interface IFlowTerminator<T> : IDisposable
    {
        Task<T> TerminateFlow(T message);
    }
}