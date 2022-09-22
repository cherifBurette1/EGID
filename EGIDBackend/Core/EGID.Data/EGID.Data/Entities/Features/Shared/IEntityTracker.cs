using System;

namespace EGID.Data
{
    public interface IEntityTracker
    {
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
        int Creator { get; set; }
        int Updator { get; set; }
    }
}
