using EGID.Ground;
using EGID.Service.Features.Common.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace EGID.Presistance.Infrastructure
{

    public class AuditDbConnectionFactory : IAuditDbConnectionFactory
    {
        public IDbConnection GetAuditDbConnection()
        {
            return new SqlConnection(Configurations.EGIDAuditConnectionString);
        }
    }

}
