using System;

namespace UniSyncFlowPoc1.Flow.BlockDefinitions.Logic
{
    public class MapperErrorDecorator<T, TY> : IFlowMapper<T, TY>
    {
        private readonly IFlowMapper<T, TY> _mapper;

        public MapperErrorDecorator(IFlowMapper<T, TY> mapper)
        {
            _mapper = mapper;
        }

        public TY Map(T message)
        {
            try
            {
                return _mapper.Map(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
        }
    }
}