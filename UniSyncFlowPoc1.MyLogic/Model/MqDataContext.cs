using System;

namespace UniSyncFlowPoc1.MyLogic
{
    public class MqDataContext
    {
        public Guid Guid { get; }

        public MqDataContext(Guid guid)
        {
            Guid = guid;
        }
    }
}