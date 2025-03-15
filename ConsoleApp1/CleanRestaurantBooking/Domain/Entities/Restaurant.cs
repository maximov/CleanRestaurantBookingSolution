using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace CleanRestaurantBooking.Domain.Entities

{
    public class Restaurant
    {
        public int Id {get; private set;}
        public string Name {get; private set;}
        public string Address {get; private set;}
        public int TotalTables {get; private set;}        
        public long? Phone {get; private set;}
        public string? Description {get; private set;}

        public Restaurant(int id, string name, string address, int totalTables, long? phone=null, string? description=null)
        {
            Id = id;
            Name = name;
            Address = address;
            TotalTables = totalTables;
            Phone = phone;
            Description = description;            
        }
        
        public bool HasFreeTables(int bookedCount)
        {
            return bookedCount < TotalTables;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Название не может быть пустым", nameof(newName));
            Name = newName;
        }

        public void UpdateTotalTables(int newTotalTables)
        {
            if (newTotalTables <= 0)
                throw new ArgumentException("Количество столиков не может быть меньше нуля", nameof(newTotalTables));
            TotalTables = newTotalTables;
        }

    }



}