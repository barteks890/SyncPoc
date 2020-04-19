namespace UniSyncFlowPoc1.Synchronizer.Core
{
    public interface ISyncMapper<T, TY>
    {
        TY Map(T context);
    }
}