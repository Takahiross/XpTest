using System.Text.RegularExpressions;

namespace XpTest.Domain.Entities
{
    public class Client
    {
        public Client() { } 
        public Client(string name, string phone, string email, Address address)
        {
            EmailValidation(email);
            PhoneValidation(phone);
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get;  set; }
        public Address Address { get; set; }

        public bool EmailValidation(string email)
        {
            string emailStandart = @"^\S+@\S+\.\S+$";
            return Regex.IsMatch(email, emailStandart);
        }

        public bool PhoneValidation(string phone)
        {
            string phoneStandard = @"^\d{10,12}$";
            return Regex.IsMatch(phone, phoneStandard);
        }
    }
}
