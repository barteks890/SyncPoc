using System.Linq;
using System.Threading.Tasks;
using UniSyncFlowPoc1.Flow.Core;

namespace UniSyncFlowPoc1.Flow.BlockDefinitions
{
    public class GeneratorBlockSet : IRunnableBlock
    {
        private readonly IRunnableBlock[] _runnableSyncSteps;

        public GeneratorBlockSet(IRunnableBlock[] runnableSyncSteps)
        {
            _runnableSyncSteps = runnableSyncSteps;
        }

        public async Task RunAsync(RunnableContext runnableContext)
        {
            await Task.WhenAll(_runnableSyncSteps.Select(r => r.RunAsync(runnableContext)).ToArray());
        }

        public void Dispose()
        {
        }
    }
}