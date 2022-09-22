using System.Data;

namespace EGID.Service.Features.Common.Interfaces
{
    public interface IAuditDbConnectionFactory
    {
        IDbConnection GetAuditDbConnection();
    }
}
