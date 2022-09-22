using Hangfire;
using System;
using EGID.Service.Features.Common.Interfaces.Helpers;

namespace EGID.Presistance.Features.Common.Implementation.Helpers
{
    public class BackgroundSchedular : IBackgroundSchedular
    {
        private readonly Lazy<IBackgroundJobClient> _backgroundJobClient;
        private readonly Lazy<IRecurringJobManager> _recurringJobManager;
        public BackgroundSchedular(Lazy<IBackgroundJobClient> backgroundJobClient,
            Lazy<IRecurringJobManager> recurringJobManager)
        {
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
        }
        private IBackgroundJobClient BackgroundJobClient => _backgroundJobClient.Value;
        private IRecurringJobManager RecurringJobManager => _recurringJobManager.Value;

        public bool RemoveScheduledJob(string jobId)
        {
            return BackgroundJobClient.Delete(jobId);
        }
        public void RemoveRecurringJob(string jobId)
        {
            RecurringJobManager.RemoveIfExists(jobId);
        }
        public string ScheduleChangePrice(int stockId)
        {
            return "hi";
            // var dateTimeUTCOffset = DateTime.SpecifyKind(DateTime.UtcNow.AddHours(10), DateTimeKind.Utc);
            // return BackgroundJobClient.Schedule<IGroupService>(x => x.ClearImportGroupTempTable(importHistoryId), dateTimeUTCOffset);
        }
        public void EnqueueChangePrice(int stockId)
        {
            // BackgroundJobClient.Enqueue<IUserService>(x => x.StartImportedUsersData(userId, model));
        }
    }
}
