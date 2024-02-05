namespace Znak.Models
{
    public class Payment : BaseEntity
    {
        public Guid OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public virtual Order Order { get; set; }
    }
}
