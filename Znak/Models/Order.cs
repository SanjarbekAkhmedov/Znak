namespace Znak.Models
{
    public class Order : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
