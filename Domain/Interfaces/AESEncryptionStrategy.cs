using PasswordManager.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

public class AesEncryptionStrategy : IEncryptionStrategy
{
    private readonly byte[] _key;
    private readonly byte[] _iv;

    public AesEncryptionStrategy()
    {
        _key = Encoding.UTF8.GetBytes("0123456789ABCDEF0123456789ABCDEF"); // Clé de 32 bytes
        _iv = Encoding.UTF8.GetBytes("0123456789ABCDEF"); // IV de 16 bytes
    }

    public string Encrypt(string plainText)
    {
        using Aes aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;

        using var encryptor = aes.CreateEncryptor();
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

        return Convert.ToBase64String(encryptedBytes);
    }

    public string Decrypt(string encryptedText)
    {
        using Aes aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;

        using var decryptor = aes.CreateDecryptor();
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

        return Encoding.UTF8.GetString(decryptedBytes);
    }
}
