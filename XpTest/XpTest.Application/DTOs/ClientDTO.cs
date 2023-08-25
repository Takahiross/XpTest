namespace XpTest.Application.DTOs
{
    public class ClientDTO
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Phone { get;  set; }
        public string Email { get;  set; }
        public AddressDTO Address { get;  set; }
    }
}
