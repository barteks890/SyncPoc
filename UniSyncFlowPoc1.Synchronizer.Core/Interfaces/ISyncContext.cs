using System;

namespace UniSyncFlowPoc1.Synchronizer.Core
{
    public interface ISyncContext
    {
        Guid ContextId { get; }
    }
}