using System.Data;

namespace CleanRestaurantBooking.Domain.Entities
{
    public class Booking
    {
        public int Id {get; private set;}
        public int ClientId {get; private set;}
        public int RestaurantId {get; private set;}
        public string Date {get; private set;}
        public string Time {get; private set;}
        public int QuantitiesClient {get; private set;}
        public string Status {get; private set;}

        public Booking (int id, int clientId, int restaurantId, 
                    string date, string time, int quantitiesClient, string status)
                {
                    Id = id;
                    ClientId = clientId;
                    RestaurantId = restaurantId;
                    Date = date;
                    Time = time;
                    QuantitiesClient = quantitiesClient;
                    Status = status;
                }
        
        public void UpdateStatus(string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
                throw new ArgumentException("Статус не может быть пустым", nameof(newStatus));
            Status = newStatus;
        }        
    }    
}