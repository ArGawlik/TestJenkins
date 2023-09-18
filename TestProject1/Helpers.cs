namespace TestProject1
{
    public class Helpers
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        const string numerics = "1234567890";
        static Random random = new Random();

        public static string RandomString(int length = 10, string startsWith = "")
        {
            return startsWith + new string(Enumerable.Repeat(chars, length - startsWith.Length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int RandomInt(int min = 0, int max = 100)
        {
            return random.Next(min, max);
        }

        public static string RandomNumericString(int length = 10, string startsWith = "")
        {
            return startsWith + new string(Enumerable.Repeat(numerics, length - startsWith.Length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
