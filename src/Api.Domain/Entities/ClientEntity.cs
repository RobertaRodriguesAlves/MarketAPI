namespace Api.Domain.Entities
{
    public class ClientEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Document { get; set; }
    }
}