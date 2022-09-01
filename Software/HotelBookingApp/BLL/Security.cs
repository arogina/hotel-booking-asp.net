using System.Security.Cryptography;

namespace BLL
{
    public class Security
    {
        public static string CreateSalt()
        {
            byte[] salt = new byte[16];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetNonZeroBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public static string HashPassword(string password, string salt)
        {
            var saltBytes = Convert.FromBase64String(salt);

            using (var rfc = new Rfc2898DeriveBytes(password, saltBytes, 1000))
            {
                return Convert.ToBase64String(rfc.GetBytes(16));
            }
        }

        public static bool IsEqualPassword(string password, string salt, string hashedPassword)
        {
            return HashPassword(password, salt) == hashedPassword;
        }
    }
}