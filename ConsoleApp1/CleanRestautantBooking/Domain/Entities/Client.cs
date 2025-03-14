
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

        public void UpdateContactInfo(string? name = null, int? phone = null, string? email = null)
        {
            if (name != null)
            {
                if (name == "")
                    throw new ArgumentException("Имя не может быть пустым");
                Name = name;
            }
                
            if (phone != null)
            {
                if (phone > 0 && (((int)phone).ToString().Length == 9 || ((int)phone).ToString().Length == 10))
                    throw new ArgumentException("Номер указан некорректно");
                Phone = (int)phone;
            }
                
            if (email != null)
                Email = email;
        }
    }
}