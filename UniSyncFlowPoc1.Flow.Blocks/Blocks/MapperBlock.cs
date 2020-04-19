using System.Threading.Tasks;
using UniSyncFlowPoc1.Flow.Core;

namespace UniSyncFlowPoc1.Flow.BlockDefinitions
{
    public class MapperBlock<T, TY> : IBlock<T>
    {
        private readonly IBlock<TY> _next;
        private readonly IFlowMapper<T, TY> _mapper;

        public MapperBlock(IBlock<TY> next, IFlowMapper<T, TY> mapper)
        {
            _next = next;
            _mapper = mapper;
        }

        public async Task ProcessAsync(T message)
        {
            TY mappedMessage = _mapper.Map(message);
            await _next.ProcessAsync(mappedMessage);
        }

        public void Dispose()
        {

        }
    }
}