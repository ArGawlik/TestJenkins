namespace TestProject1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Address Address { get; set; }

        public static User GenerateUser() 
        {
            return new User
            {
                Id = Helpers.RandomInt(),
                Name = Helpers.RandomString(),
                Surname = Helpers.RandomString(),
                Address = Address.GenerateAddress()
            };
        }
    }
}
