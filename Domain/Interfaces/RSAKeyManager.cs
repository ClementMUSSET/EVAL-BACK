using System.Security.Cryptography;

public class RsaKeyManager
{
    private const string PrivateKeyPath = "private_key.xml";
    private const string PublicKeyPath = "public_key.xml";

    public static void GenerateKeys()
    {
        using var rsa = RSA.Create(2048);

        // Sauvegarde la clé privée (uniquement côté serveur)
        File.WriteAllText(PrivateKeyPath, rsa.ToXmlString(true));

        // Sauvegarde la clé publique (peut être envoyée aux clients)
        File.WriteAllText(PublicKeyPath, rsa.ToXmlString(false));
    }

    public static string GetPublicKey()
    {
        return File.Exists(PublicKeyPath) ? File.ReadAllText(PublicKeyPath) : throw new FileNotFoundException("Clé publique introuvable.");
    }

    public static string GetPrivateKey()
    {
        return File.Exists(PrivateKeyPath) ? File.ReadAllText(PrivateKeyPath) : throw new FileNotFoundException("Clé privée introuvable.");
    }
}
