using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
    public string HashSHA512(string payloadJson, string privateKeyFile)
    {
        // Load private key từ file
        var privateKeyFilePath = AppContext.BaseDirectory + "\\Secrets\\" + privateKeyFile;
        // Load private key từ file
        var privateKey = System.IO.File.ReadAllText(privateKeyFilePath);
        var rsa = System.Security.Cryptography.RSA.Create();
        rsa.ImportFromPem(privateKey.ToCharArray());

        // Tạo đối tượng RS512 signature algorithm
        var rsaSecurityKey = new RsaSecurityKey(rsa);
        var signingCredentials = new SigningCredentials(rsaSecurityKey, SecurityAlgorithms.RsaSha512);

        // Chuyển chuỗi JSON payload thành Dictionary
        var payloadDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(payloadJson) ?? throw new Exception("Payload is invalid!");

        // Chuyển Dictionary thành danh sách các Claim
        var claims = new List<Claim>();
        foreach (var kvp in payloadDictionary)
        {
            if (kvp.Value is Newtonsoft.Json.Linq.JObject)
            {
                // Nếu giá trị là đối tượng JSON, chuyển thành chuỗi JSON
                var jsonString = JsonConvert.SerializeObject(kvp.Value);
                claims.Add(new Claim(kvp.Key, jsonString));
            }
            else if (kvp.Value is Newtonsoft.Json.Linq.JArray)
            {
                // Nếu giá trị là mảng JSON, chuyển thành chuỗi JSON
                var jsonString = JsonConvert.SerializeObject(kvp.Value);
                claims.Add(new Claim(kvp.Key, jsonString));
            }
            else
            {
                // Nếu là giá trị đơn giản, chuyển trực tiếp thành chuỗi
                claims.Add(new Claim(kvp.Key, kvp.Value.ToString()));
            }
        }

        // Tạo payload từ danh sách Claim
        var payloadObject = new JwtPayload(claims);

        // Tạo và ký JWT
        var header = new JwtHeader(signingCredentials);
        var jwt = new JwtSecurityToken(header, payloadObject);
        var jwtHandler = new JwtSecurityTokenHandler();
        return jwtHandler.WriteToken(jwt);
    }

    /// <inheritdoc/>
    public bool VerifySignature(string token, string publicKeyFile)
    {
        var publicKeyFilePath = AppContext.BaseDirectory + "\\Secrets\\" + publicKeyFile;
        var publicKey = File.ReadAllText(publicKeyFilePath);
        var rsa = RSA.Create();
        rsa.ImportFromPem(publicKey.ToCharArray());

        var rsaSecurityKey = new RsaSecurityKey(rsa);
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            IssuerSigningKey = rsaSecurityKey
        };

        try
        {
            // Parse token và xác minh
            var jwtHandler = new JwtSecurityTokenHandler();
            var principal = jwtHandler.ValidateToken(token, validationParameters, out var validatedToken);
            return true;  // Nếu không xảy ra lỗi, nghĩa là xác minh thành công
        }
        catch (Exception)
        {
            return false;  // Nếu có lỗi xảy ra trong quá trình xác minh
        }
    }
}
