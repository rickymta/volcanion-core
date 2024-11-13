using System.Text.Json;
using System.Text.RegularExpressions;
using Volcanion_Core_Common.Abstractions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Volcanion_Core_Common.Implementations;

/// <inheritdoc/>
public class StringProvider : IStringProvider
{
    /// <inheritdoc/>
    public string FormatNumber(object number)
    {
        // Check if the number is a valid number.
        return $"{number:n0}";
    }

    /// <inheritdoc/>
    public string GenerateOTP(int length = 6)
    {
        // Generate a random number.
        var chars1 = "1234567890";
        // Generate a random string.
        var stringChars1 = new char[length];
        // Generate a random number.
        var random1 = new Random();

        // Generate a random number.
        for (int i = 0; i < stringChars1.Length; i++)
        {
            // Generate a random number.
            stringChars1[i] = chars1[random1.Next(chars1.Length)];
        }

        // Return the random string.
        return new string(stringChars1);
    }

    /// <inheritdoc/>
    public string SerializeUtf8<T>(T data)
    {
        // Serialize the data to JSON.
        return JsonSerializer.Serialize(data, typeof(T), new JsonSerializerOptions() { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All) });
    }

    /// <inheritdoc/>
    public bool CheckNumeric(string text)
    {
        // Check if the text is numeric.
        return double.TryParse(text, out _);
    }

    /// <inheritdoc/>
    public string FormatPhoneNumber(string phoneNumber)
    {
        // Remove all the spaces, dots, and commas.
        phoneNumber = phoneNumber.Replace(" ", "").Replace(".", "").Replace(",", "");
        // Check if the phone number is numeric.
        if (!CheckNumeric(phoneNumber)) return phoneNumber.ToLower();
        // Check if the phone number is a valid phone number.
        if (phoneNumber.StartsWith("84") && phoneNumber.Length == 11) phoneNumber = "0" + phoneNumber[2..];
        // Check if the phone number is a valid phone number.
        else if (!phoneNumber.StartsWith("0") && phoneNumber.Length == 9) phoneNumber = "0" + phoneNumber;
        // Return the formatted phone number.
        return phoneNumber.ToLower();
    }

    /// <inheritdoc/>
    public string RandomString(int length)
    {
        // Generate a random string.
        var random = new Random();
        // The characters to use.
        const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        // Return the random string.
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }

    /// <inheritdoc/>
    public bool CheckNormalText(string text)
    {
        // Check if the text is a normal text.
        var regexItem = new Regex("^[a-zA-Z0-9]*$");
        // Return the result.
        return regexItem.IsMatch(text);
    }

    /// <inheritdoc/>
    public long? GetNumberFromText(string text, string preText, string nextText, List<string>? replace = null)
    {
        // Remove all the characters in the replace list.
        replace ??= new List<string> { ",", "." };

        // Remove all the characters in the replace list.
        foreach (var item in replace)
        {
            // Remove the item from the text.
            text = text.Replace(item, "");
        }

        // Create the pattern.
        var pattern = $@"{preText}([0-9]+){nextText}";
        // Find the match.
        Match m = Regex.Match(text, pattern, RegexOptions.IgnoreCase);

        // If the match is found, return the number.
        if (m.Success)
        {
            var numberString = m.Value.Replace(preText, "").Replace(nextText, "").Trim();
            return Convert.ToInt64(numberString);
        }

        return null;
    }

    /// <inheritdoc/>
    public string ReplaceFirst(string text, string search, string replace)
    {
        // Find the first occurrence of the search string.
        int pos = text.IndexOf(search);
        // If no occurrence is found, return the original string.
        if (pos < 0) return text;
        // Return the string with the replacement.
        return string.Concat(text.AsSpan(0, pos), replace, text.AsSpan(pos + search.Length));
    }

    /// <inheritdoc/>
    public bool IsValidEmail(string email)
    {
        // Return true if str is in valid e-mail format.
        var trimmedEmail = email.Trim();

        // Return false if str is empty or null.
        if (trimmedEmail.EndsWith(".")) return false;

        try
        {
            // Use MailAddress to validate the address.
            var addr = new System.Net.Mail.MailAddress(email);
            // Return true if the address is valid.
            return addr.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }

    /// <inheritdoc/>
    public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        // Add the timestamp to the date
        dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        // Return the date
        return dateTime;
    }

    /// <inheritdoc/>
    public string GetTimestamp(DateTime value)
    {
        // 2021-09-01T00:00:00.0000000
        return value.ToString("yyyyMMddHHmmssffff");
    }

    /// <inheritdoc/>
    public DateTimeOffset GenerateDateTimeOffsetFromString(string data)
    {
        // 1d, 1h, 1m, 1s, 1y, 1M
        if (string.IsNullOrEmpty(data) || data.Length < 2) throw new ArgumentException("Invalid input format.");

        // Get the last character
        char timeUnit = data[^1];
        // Get the number part
        string numberPart = data[0..^1];

        // Check if the number part is a valid number
        if (!int.TryParse(numberPart, out int value)) throw new ArgumentException("Invalid numeric value.");
        // Get the current time
        var res = DateTimeOffset.UtcNow;

        // Add the value to the current time
        return timeUnit switch
        {
            's' => res.AddSeconds(value),
            'h' => res.AddHours(value),
            'd' => res.AddDays(value),
            'M' => res.AddMonths(value),
            'y' => res.AddYears(value),
            _ => res.AddMinutes(value),
        };
    }
}
