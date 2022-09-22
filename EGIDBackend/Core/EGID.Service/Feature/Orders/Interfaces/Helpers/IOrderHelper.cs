namespace EGID.Service.Features.Orders.Interfaces.Helpers
{
    public interface IOrdersHelper
    {
        public double CalculateCommission(double stockPrice, bool isClient);
    }
}
