using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniSyncFlowPoc1.Flow.BlockDefinitions;
using UniSyncFlowPoc1.Flow.BlockDefinitions.Logic;
using UniSyncFlowPoc1.Flow.Core;
using UniSyncFlowPoc1.MyLogic;

namespace UniSyncFlowPoc1
{
    class Program
    {
        static async Task Main()
        {
            IFlowTerminator<SqlDataContext> flowTerminator = new SqlTerminator();
            TerminationBlock<SqlDataContext> terminationBlock = new TerminationBlock<SqlDataContext>(flowTerminator);

            IFlowMapper<MqDataContext, SqlDataContext> mapper = new MqToSqlMapper();
            MapperErrorDecorator<MqDataContext, SqlDataContext> mapperErrorDecorator = new MapperErrorDecorator<MqDataContext, SqlDataContext>(mapper);

            CounterDecoratorBlock<SqlDataContext> counterDecoratorBlock = new CounterDecoratorBlock<SqlDataContext>(terminationBlock);

            MapperBlock<MqDataContext, SqlDataContext> mapperBlock = new MapperBlock<MqDataContext, SqlDataContext>(counterDecoratorBlock, mapperErrorDecorator);

            List<GeneratorBlock<MqDataContext>> generatorBlocks = new List<GeneratorBlock<MqDataContext>>();
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                IFlowGenerator<MqDataContext> flowGenerator = new MqFlowGenerator();
                GeneratorBlock<MqDataContext> generatorBlock = new GeneratorBlock<MqDataContext>(mapperBlock, flowGenerator);
                generatorBlocks.Add(generatorBlock);
            }

            GeneratorBlockSet generatorBlockSet = new GeneratorBlockSet(generatorBlocks.ToArray());

            IFlow flow = new DefaultFlow(generatorBlockSet);

            await flow.RunAsync(new RunnableContext
            {
                CancellationToken = new CancellationToken()
            });
        }
    }

    public class CounterDecoratorBlock<T> : IBlock<T>
    {
        private readonly IBlock<T> _decoratedBlock;
        private long _messageCount;

        public CounterDecoratorBlock(IBlock<T> decoratedBlock)
        {
            _decoratedBlock = decoratedBlock;
        }

        public async Task ProcessAsync(T message)
        {
            Interlocked.Increment(ref _messageCount);
            await _decoratedBlock.ProcessAsync(message);
        }

        public void Dispose()
        {
        }
    }
}
