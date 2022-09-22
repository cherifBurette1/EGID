using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EGID.Data.Entities
{
    public class Order : IEntityWithId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Commission { get; set; }
        public int StockId { get; set; }
        public virtual Stock Stock { get; set; }
        public int BrokerId { get; set; }
        public virtual Broker Broker { get; set; }
        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
