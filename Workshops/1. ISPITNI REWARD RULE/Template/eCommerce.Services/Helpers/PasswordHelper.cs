using System;
using System.Security.Cryptography;

namespace eCommerce.Services.Helpers
{
    public static class PasswordHelper
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 10000;

        /// <summary>
        /// Generates a random salt for password hashing
        /// </summary>
        /// <returns>Base64 encoded salt string</returns>
        public static string GenerateSalt()
        {
            var salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        /// <summary>
        /// Generates a password hash using PBKDF2 with the provided salt
        /// </summary>
        /// <param name="salt">Base64 encoded salt string</param>
        /// <param name="password">Plain text password</param>
        /// <returns>Base64 encoded password hash</returns>
        public static string GenerateHash(string salt, string password)
        {
            var saltBytes = Convert.FromBase64String(salt);
            
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations))
            {
                return Convert.ToBase64String(pbkdf2.GetBytes(KeySize));
            }
        }

        /// <summary>
        /// Verifies a password against its hash and salt
        /// </summary>
        /// <param name="password">Plain text password to verify</param>
        /// <param name="passwordHash">Base64 encoded password hash</param>
        /// <param name="passwordSalt">Base64 encoded password salt</param>
        /// <returns>True if password matches, false otherwise</returns>
        public static bool VerifyPassword(string password, string passwordHash, string passwordSalt)
        {
            var salt = Convert.FromBase64String(passwordSalt);
            var hash = Convert.FromBase64String(passwordHash);
            var hashBytes = new Rfc2898DeriveBytes(password, salt, Iterations).GetBytes(KeySize);
            return hash.SequenceEqual(hashBytes);
        }
    }
}
