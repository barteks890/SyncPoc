using System.Threading.Tasks;

namespace UniSyncFlowPoc1.Flow.Core
{
    public class DefaultFlow : IFlow
    {
        private readonly IRunnableBlock _runnableBlock;

        public DefaultFlow(IRunnableBlock runnableBlock)
        {
            _runnableBlock = runnableBlock;
        }

        public Task RunAsync(RunnableContext runnableContext)
        {
            return _runnableBlock.RunAsync(runnableContext);
        }

        public void Dispose()
        {
        }
    }
}
