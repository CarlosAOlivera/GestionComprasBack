using System;
using System.Security.Cryptography;

public static class TokenGenerator
{
    public static string GenerateToken()
    {
        using (var randomNumberGenerator = new RNGCryptoServiceProvider())
        {
            var tokenData = new byte[32];
            randomNumberGenerator.GetBytes(tokenData);
            return Convert.ToBase64String(tokenData);
        }
    }
}
