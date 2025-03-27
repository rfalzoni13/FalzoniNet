using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace FalzoniNetApi.Utils.Helpers
{
    public static class PasswordHelper
    {
        public static string GeneratePassword(string? character = null)
        {
            if (character == null)
            {
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

                char[] arrChar = new char[8];
                Random rnd = new Random();

                for (int i = 0; i < arrChar.Length; i++)
                {
                    arrChar[i] = alphabet[rnd.Next(alphabet.Length)];
                }

                character = new String(arrChar);
            }

            return character.HashPassword();
        }

        private static string HashPassword(this string password)
        {
            const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1; // default for Rfc2898DeriveBytes
            const int Pbkdf2IterCount = 1000; // default for Rfc2898DeriveBytes
            const int Pbkdf2SubkeyLength = 256 / 8; // 256 bits
            const int SaltSize = 128 / 8; // 128 bits
            Random rnd = new Random();
            int number = rnd.Next(1, 15);

            // Produce a version 2 text hash.
            byte[] salt = new byte[SaltSize];
            byte[] subkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

            var outputBytes = new byte[1 + SaltSize + Pbkdf2SubkeyLength];
            outputBytes[0] = 0x00; // format marker
            Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, Pbkdf2SubkeyLength);
            string hashed = Convert.ToBase64String(outputBytes);

            return hashed;
        }
    }
}
