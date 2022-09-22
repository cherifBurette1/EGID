namespace EGID.DTO.Models
{
    public class DTOOrder
    {
        public int Id { get; set; }
        public int BrokerId { get; set; }
        public int? PersonId { get; set; }
        public double Price { get; set; }
        public double? Commission { get; set; }
        public string StockName { get; set; }
        public int Quantity { get; set; }
    }
    public class DTOOrderList
    {
        public int Id { get; set; }
        public string BrokerName { get; set; }
        public string PersonName { get; set; }
        public double Price { get; set; }
        public double? Commission { get; set; }
        public string StockName { get; set; }
        public int Quantity { get; set; }
    }
}
