
using System.Dynamic;

namespace CleanRestaurantBooking.Domain.Entities
{
    public class Client
    {
        public int Id {get; private set;}
        public string Name {get; private set;}
        public long Phone {get; private set;}
        public string? Email {get; private set;}

        public Client(int id, string name, long phone, string? email = null)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
        }

        public void UpdateContactInfo(string? name = null, long? phone = null, string? email = null)
        {
            if (name != null)
            {
                if (name == "")
                    throw new ArgumentException("Имя не может быть пустым");
                Name = name;
            }
                
            if (phone != null)
            {
                if (phone > 0 && (((long)phone).ToString().Length == 9 || ((long)phone).ToString().Length == 10))
                    throw new ArgumentException("Номер указан некорректно");
                Phone = (long)phone;
            }
                
            if (email != null)
                Email = email;
        }
    }
}