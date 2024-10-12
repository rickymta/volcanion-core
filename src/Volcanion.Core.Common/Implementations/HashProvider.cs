using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;
using Volcanion.Core.Common.Abstractions;

namespace Volcanion.Core.Common.Implementations
{
    /// <summary>
    /// HashProvider
    /// </summary>
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
    }
}
