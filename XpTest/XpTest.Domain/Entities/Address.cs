namespace XpTest.Domain.Entities
{
    public class Address
    {
        public Address() { }
        public Address(string street, string streetNumber, string city)
        {
            Street = street;
            StreetNumber = streetNumber;
            City = city;
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public int ClientId { get; set; }  
        public Client Client { get; set; }
    }
}
