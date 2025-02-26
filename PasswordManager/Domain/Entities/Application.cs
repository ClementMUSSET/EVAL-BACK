namespace PasswordManager.Domain.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // "Grand public" ou "Professionnelle"
        public ICollection<PasswordEntry> Passwords { get; set; } = new List<PasswordEntry>();
    }
}
