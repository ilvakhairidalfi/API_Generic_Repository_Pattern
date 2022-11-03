namespace API.Handler
{
    public class Hashing
    {
        // method salt dulu
        private static string GetRamdomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        // method hash
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRamdomSalt());
        }

        //method validate
        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}
