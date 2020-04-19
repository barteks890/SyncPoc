using System;
using System.Threading.Tasks;
using UniSyncFlowPoc1.Flow.BlockDefinitions;

namespace UniSyncFlowPoc1.MyLogic
{
    public class MqFlowGenerator : IFlowGenerator<MqDataContext>
    {
        private readonly Guid _guid = Guid.NewGuid();

        public MqFlowGenerator()
        {
        }

        public async Task<MqDataContext> GenerateMessageAsync()
        {
            return await Task.Factory.StartNew(() => new MqDataContext(_guid));
        }

        public void PostProcess(MqDataContext message)
        {
        }

        public void OnError(MqDataContext message, Exception exception)
        {
        }

        public void Dispose()
        {
        }
    }
}