namespace PasswordManager.Domain.Interfaces
{
    public interface IEncryptionStrategy
    {
        string Encrypt(string password);
        string Decrypt(string encryptedText);
    }
}
