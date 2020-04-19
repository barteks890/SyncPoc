using System;
using System.Threading.Tasks;
using UniSyncFlowPoc1.Flow.Core;

namespace UniSyncFlowPoc1.Flow.BlockDefinitions
{
    public class GeneratorBlock<T> : IRunnableBlock
    {
        private readonly IBlock<T> _next;
        private readonly IFlowGenerator<T> _flowGenerator;

        public GeneratorBlock(IBlock<T> next, IFlowGenerator<T> flowGenerator)
        {
            _next = next;
            _flowGenerator = flowGenerator;
        }

        public async Task RunAsync(RunnableContext runnableContext)
        {
            while (true)
            {
                try
                {
                    await ProcessRun();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private async Task ProcessRun()
        {
            T message = default;
            try
            {
                message = await _flowGenerator.GenerateMessageAsync();
                await _next.ProcessAsync(message);
                _flowGenerator.PostProcess(message);
            }
            catch (Exception e)
            {
                _flowGenerator.OnError(message, e);
            }
        }

        public void Dispose()
        {

        }
    }
}