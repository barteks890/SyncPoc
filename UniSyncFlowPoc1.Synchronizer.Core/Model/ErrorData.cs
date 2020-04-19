using System;

namespace UniSyncFlowPoc1.Synchronizer.Core
{
    public class ErrorData
    {
        public bool ErrorFlag { get; }

        public string ErrorMessage { get; }

        public Exception Exception { get; }
    }
}
