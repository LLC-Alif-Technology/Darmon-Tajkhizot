using System;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public static class JwtHelper
    {
        // Generates a random string (token)
        public static string GetRandomString()
        {
            // Base 64 encoded guid
            return Encode();
        }
        public static string Encode()
        {
            return Encode(Guid.NewGuid());
        }

        private static string Encode(Guid guid)
        {
            return Convert.ToBase64String(guid.ToByteArray()).Replace("/", "_").Replace("+", "-")[..22];
        }

        public static void CreatePasswordHash(
        string password,
        out byte[] passwordHash,
        out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
