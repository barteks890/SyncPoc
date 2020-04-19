using UniSyncFlowPoc1.Flow.BlockDefinitions;

namespace UniSyncFlowPoc1.MyLogic
{
    public class MqToSqlMapper : IFlowMapper<MqDataContext, SqlDataContext>
    {
        public MqToSqlMapper()
        {
        }

        public SqlDataContext Map(MqDataContext message)
        {
            return new SqlDataContext(message.Guid);
        }

        public void Dispose()
        {
        }
    }
}