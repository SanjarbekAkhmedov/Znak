namespace Znak.Model.Entities
{
    public class Customer : Person
    {
        public Guid ZnakSystemId { get; set; }
        public ZnakSystem ZnakSystem { get; set; }
    }
}
