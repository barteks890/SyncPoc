using System.Threading;

namespace UniSyncFlowPoc1.Flow.Core
{
    public class RunnableContext
    {
        public CancellationToken CancellationToken { get; set; }
    }
}