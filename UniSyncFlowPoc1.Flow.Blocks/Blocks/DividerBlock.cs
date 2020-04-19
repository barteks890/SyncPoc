using System.Linq;
using System.Threading.Tasks;
using UniSyncFlowPoc1.Flow.Core;

namespace UniSyncFlowPoc1.Flow.BlockDefinitions
{
    public class DividerBlock<T> : IBlock<T>
    {
        private readonly IBlock<T>[] _outputBlocks;
        private readonly IFlowDivider _flowDivider; //TODO: !!!

        public DividerBlock(IBlock<T>[] outputBlocks, IFlowDivider flowDivider)
        {
            _outputBlocks = outputBlocks;
            _flowDivider = flowDivider;
        }

        public async Task ProcessAsync(T message)
        {
            await Task.WhenAll(_outputBlocks.Select(b => b.ProcessAsync(message)).ToArray());
        }

        public void Dispose()
        {
        }
    }
}