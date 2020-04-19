namespace UniSyncFlowPoc1.Synchronizer.Core
{
    public interface ISyncTransaction
    {
        void Commit();

        void Rollback();
    }
}