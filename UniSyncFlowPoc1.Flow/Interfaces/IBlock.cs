using System;
using System.Threading.Tasks;

namespace UniSyncFlowPoc1.Flow.Core
{
    public interface IBlock : IDisposable
    {
    }

    public interface IBlock<in T> : IBlock
    {
        Task ProcessAsync(T message);
    }
}