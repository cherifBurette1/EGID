namespace EGID.Service.Features.Common.Interfaces.Helpers
{
    public interface IBackgroundSchedular
    {
        string ScheduleChangePrice(int stockId);
        bool RemoveScheduledJob(string jobId);
        void EnqueueChangePrice(int stockId);
    }
}
