namespace Znak.Model.Entities
{
    public class ZnakSystem : BaseEntity
    {
        public ZnakSystem()
        {
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<User> Users { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
