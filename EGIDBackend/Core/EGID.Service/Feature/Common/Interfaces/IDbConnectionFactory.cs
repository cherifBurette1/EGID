using System.Data;

namespace EGID.Service.Features.Common.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetDbConnection();
    }
}
