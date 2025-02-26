using PasswordManager.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

public class RsaEncryptionStrategy : IEncryptionStrategy
{
    private readonly RSA _rsa;

    public RsaEncryptionStrategy()
    {
        _rsa = RSA.Create();
        _rsa.KeySize = 2048; // Clé RSA 2048 bits
    }

    public string Encrypt(string plainText)
    {
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] encryptedBytes = _rsa.Encrypt(plainBytes, RSAEncryptionPadding.OaepSHA256);
        return Convert.ToBase64String(encryptedBytes);
    }

    public string Decrypt(string encryptedText)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        byte[] decryptedBytes = _rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.OaepSHA256);
        return Encoding.UTF8.GetString(decryptedBytes);
    }
}
