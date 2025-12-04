using System.Security.Cryptography;
using System.Text;

namespace EgyptionPioneersProject.Utils
{
    public static class HashHelper
    {
        public static string Hash(string input)
        {
            if (string.IsNullOrEmpty(input)) return input ?? "";
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToHexString(hash);
        }

        public static bool VerifyPassword(string input, string hashed)
        {
            return Hash(input) == hashed;
        }
    }
}
