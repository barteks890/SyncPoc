using System;
using System.Threading.Tasks;

namespace UniSyncFlowPoc1.Flow.BlockDefinitions
{
    public interface IFlowGenerator<T> : IDisposable
    {
        Task<T> GenerateMessageAsync();

        void PostProcess(T message);
        
        void OnError(T message, Exception exception);
    }
}