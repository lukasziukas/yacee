namespace YACEE.WEB.Models
{
    public class User
    {
        public long UserId { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public byte[] Hash { get; set; }

        public byte[] Salt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime LastLogin { get; set; }
    }
}
