namespace Znak.Model.Entities
{
    public class User : Person
    {
        public UserRole UserRole { get; set; }
        public Guid? ZnakSystemId { get; set; }
        public virtual ZnakSystem? ZnakSystem { get; set; }
        public override string ToString()
        {
            return $"Имя:{FirstName}, Фамилия:{LastName}, Email:{Email}, Тел:{Phone}, Логин:{Login}";
        }
    }
}
