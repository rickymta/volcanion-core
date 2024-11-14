using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;
using Volcanion.Core.Common.Abstractions;

namespace Volcanion.Core.Common.Implementations;

/// <inheritdoc/>
public class HashProvider : IHashProvider
{
    /// <inheritdoc/>
    public string HashPassword(string password)
    {
        return new PasswordHasher<object>().HashPassword(null, password);
    }

    /// <inheritdoc/>
    public bool VerifyPassword(string hashedPassword, string password)
    {
        return new PasswordHasher<object>().VerifyHashedPassword(null, hashedPassword, password) != PasswordVerificationResult.Failed;
    }

    /// <inheritdoc/>
    public string CreateMD5(string input)
    {
        // Use input string to calculate MD5 hash
        using MD5 md5 = MD5.Create();
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        // Convert the byte array to hexadecimal string
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("X2"));
        }

        return sb.ToString().ToLower();
    }

    /// <inheritdoc/>
    public string SHA256Encrypt(string input, string secret)
    {
        var encoding = new ASCIIEncoding();
        byte[] keyByte = encoding.GetBytes(secret);
        byte[] messageBytes = encoding.GetBytes(input);

        using HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);
        byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
        return Convert.ToBase64String(hashmessage);
    }

    /// <inheritdoc/>
    public string Base64Encode(string plainText)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }

    /// <inheritdoc/>
    public string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }

    /// <inheritdoc/>
    public string HashSHA512(string data, string privateKeyFile)
    {
        // Get the private key from the file or string
        privateKeyFile = AppContext.BaseDirectory + "\\Secrets\\" + privateKeyFile;
        // Read the private key from the file
        var privateKey = File.ReadAllText(privateKeyFile);
        // Create a new instance of RSA
        using var rsa = RSA.Create();
        // Import the private key
        rsa.ImportFromPem(privateKey);
        // Hash the data with SHA512
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        // Sign the hash with the private key
        var signedHash = rsa.SignData(dataBytes, HashAlgorithmName.SHA512, RSASignaturePadding.Pkcs1);
        // Return the signed hash as a base64 string
        return Convert.ToBase64String(signedHash);
    }

    /// <inheritdoc/>
    public bool VerifySignature(string data, string dataCompare, string publicKeyFile)
    {
        // Get the public key from the file or string
        publicKeyFile = AppContext.BaseDirectory + "\\Secrets\\" + publicKeyFile;
        var publicKey = File.ReadAllText(publicKeyFile);
        // Decode the base64 signature
        using var rsa = RSA.Create();
        // Import the public key
        rsa.ImportFromPem(publicKey);
        // Hash the data with SHA512
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        byte[] signature = Encoding.UTF8.GetBytes(dataCompare);
        // Verify the signature with the public key
        return rsa.VerifyData(dataBytes, signature, HashAlgorithmName.SHA512, RSASignaturePadding.Pkcs1);
    }
}
