

using Hangfire;
using EGID.Service.Features.Common.Interfaces;
using EGID.Service.Features.Common.Interfaces.Helpers;
using System;

namespace EGID.Api.Background
{
    /// <summary>
    /// EGIDBackgroundConfiguration
    /// </summary>
    public class EGIDBackgroundConfiguration : IEGIDBackgroundConfiguration
    {
        private readonly Lazy<IBackgroundJobClient> _backgroundJobClient;
        private readonly Lazy<IRecurringJobManager> _recurringJobManager;
        /// <summary>
        /// EGIDBackgroundConfiguration
        /// </summary>
        /// <param name="backgroundJobClient"></param>
        /// <param name="recurringJobManager"></param>
        public EGIDBackgroundConfiguration(Lazy<IBackgroundJobClient> backgroundJobClient,
        Lazy<IRecurringJobManager> recurringJobManager)
        {
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
        }
        private IBackgroundJobClient BackgroundJobClient => _backgroundJobClient.Value;
        private IRecurringJobManager RecurringJobManager => _recurringJobManager.Value;

        /// <summary>
        /// StartJobs
        /// </summary>
        /// <param name="context"></param>
        /// <param name="schedular"></param>
        [Queue("default")]
        public void StartJobs(IEGIDEntities context, IBackgroundSchedular schedular)
        {


        }
    }
}