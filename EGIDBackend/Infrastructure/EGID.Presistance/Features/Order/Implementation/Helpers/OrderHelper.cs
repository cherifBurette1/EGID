namespace EGID.Service.Features.Orders.Interfaces.Helpers
{
    public class OrderHelper : IOrdersHelper
    {
        public double CalculateCommission(double stockPrice, bool isClient)
        {
            if (isClient)
            {
                return stockPrice * 0.02;
            }
            else
            {
                return stockPrice * 0.01;
            }
        }
    }
}
