using System;
using System.Threading.Tasks;
using UniSyncFlowPoc1.Flow.BlockDefinitions;

namespace UniSyncFlowPoc1.MyLogic
{
    public class SqlTerminator : IFlowTerminator<SqlDataContext>
    {
        public SqlTerminator()
        {
        }

        public async Task<SqlDataContext> TerminateFlow(SqlDataContext message)
        {
            return await Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Context guid: " + message.Guid);
                return new SqlDataContext(Guid.Empty);
            });
        }

        public void Dispose()
        {
        }
    }
}