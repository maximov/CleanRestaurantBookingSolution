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

        public void UpdateDateTime(string newDate, string newTime)
        {
            if (string.IsNullOrWhiteSpace(newDate))
                throw new ArgumentException("Дата не может быть пустой", nameof(newDate));

            if (string.IsNullOrWhiteSpace(newTime))
                throw new ArgumentException("Время не может быть пустым", nameof(newTime));

            Date = newDate;
            Time = newTime;
        }

        public void UpdateQuantitiesClient(int newQuantity)
        {
            if (newQuantity <= 0)
                throw new ArgumentException("Колиичество гостей должно быть больше нуля", nameof(newQuantity));

            QuantitiesClient = newQuantity;
        }
    }    
}