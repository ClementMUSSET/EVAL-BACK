namespace PasswordManager.Domain.Entities
{
    public class Password
    {
        public int Id { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public string EncryptedPassword { get; set; } = string.Empty;
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
