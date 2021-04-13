using System;

namespace Api.Domain.DTO.Client
{
    public class ClientDTOResult
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public DateTime CreatAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}