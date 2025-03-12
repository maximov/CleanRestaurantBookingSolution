
using System.Dynamic;

namespace CleanRestaurantBooking.Domain.Entities
{
    public class Client
    {
        public int Id {get; private set;}
        public string Name {get; private set;}
        public int Phone {get; private set;}
        public string? Email {get; private set;}

        public Client(int id, string name, int phone, string? email = null)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
        }
    }
}