using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Domain.Interfaces
{
    public class AesEncryptionStrategy : IEncryptionStrategy
    {
        private readonly string _key = "MINEAESSecretKey789";

        public string Encrypt(string password)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(_key);
            aesAlg.GenerateIV();

            using var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using var msEncrypt = new MemoryStream();
            using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using var swEncrypt = new StreamWriter(csEncrypt);

            swEncrypt.Write(password);
            swEncrypt.Flush();
            csEncrypt.FlushFinalBlock();

            byte[] encryptedData = msEncrypt.ToArray();
            return Convert.ToBase64String(aesAlg.IV.Concat(encryptedData).ToArray());
        }
    }
}
