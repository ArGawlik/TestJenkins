namespace TestProject1.Models
{
    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string HouseNumber { get; set; }
        public int? ApartmentNumber { get; set; }

        public static Address GenerateAddress(bool apartment = true) 
        {
            return new Address
            {
                Country = Helpers.RandomString(),
                City = Helpers.RandomString(),
                Zip = Helpers.RandomString(),
                HouseNumber = Helpers.RandomNumericString(2),
                ApartmentNumber =  apartment ? Helpers.RandomInt() : null
            };
        }
    }
}
