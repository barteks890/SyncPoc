using System;

namespace UniSyncFlowPoc1.MyLogic
{
    public class SqlDataContext
    {
        public Guid Guid { get; }

        public SqlDataContext(Guid guid)
        {
            Guid = guid;
        }
    }
}