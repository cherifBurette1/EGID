

using EGID.Service.Features.Common.Interfaces;
using EGID.Service.Features.Common.Interfaces.Helpers;

namespace EGID.Api.Background
{
    /// <summary>
    /// IEGIDBackgroundConfiguration
    /// </summary>
    public interface IEGIDBackgroundConfiguration
    {
        /// <summary>
        /// StartJobs
        /// </summary>
        /// <param name="context"></param>
        /// <param name="schedular"></param>
        void StartJobs(IEGIDEntities context, IBackgroundSchedular schedular);
    }
}