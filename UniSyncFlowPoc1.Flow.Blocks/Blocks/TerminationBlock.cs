using System.Threading.Tasks;
using UniSyncFlowPoc1.Flow.Core;

namespace UniSyncFlowPoc1.Flow.BlockDefinitions
{
    public class TerminationBlock<T> : IBlock<T>
    {
        private readonly IFlowTerminator<T> _terminator;

        public TerminationBlock(IFlowTerminator<T> terminator)
        {
            _terminator = terminator;
        }

        public async Task ProcessAsync(T message)
        {
            await _terminator.TerminateFlow(message);
        }

        public void Dispose()
        {
        }
    }
}