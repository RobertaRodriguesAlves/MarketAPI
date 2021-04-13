namespace Api.Domain.Models.Client
{
    public class ClientModel : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Document { get; set; }
    }
}