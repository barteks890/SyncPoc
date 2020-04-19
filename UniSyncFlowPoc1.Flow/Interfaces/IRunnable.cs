using System;
using System.Threading.Tasks;

namespace UniSyncFlowPoc1.Flow.Core
{
    public interface IRunnable : IDisposable
    {
        Task RunAsync(RunnableContext runnableContext);
    }
}