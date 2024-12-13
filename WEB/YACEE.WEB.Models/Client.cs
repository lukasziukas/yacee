namespace YACEE.WEB.Models
{
    public class Client
    {
        public long ClientId { get; set; }

        public long UserId { get; set; }

        public ClientType ClientType { get; set; }
    }
}
