using Hangfire.Common;
using Hangfire.States;
using Hangfire.Storage;
using System;

namespace EGID.HangfireServer.Filters
{
    public class JobRetentionFilter : JobFilterAttribute, IApplyStateFilter
    {
        public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            context.JobExpirationTimeout = TimeSpan.FromDays(7);
        }

        public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            context.JobExpirationTimeout = TimeSpan.FromDays(7);
        }
    }
}
