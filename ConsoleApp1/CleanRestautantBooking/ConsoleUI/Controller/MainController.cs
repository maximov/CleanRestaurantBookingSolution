using CleanRestaurantBooking.Domain.Entities;
using CleanRestaurantBooking.Application.Interfaces;
using System.Linq;
using CleanRestaurantBooking.Application.Services;

namespace CleanRestaurantBooking.ConsoleUI.Controller
{
    public class MainController
    {
        private readonly RestaurantService _restaurantService;
        private readonly ClientService _clientService;
        private readonly BookingService _bookingService;

        public MainController(RestaurantService restaurantService, ClientService clientService, BookingService bookingService)
        {
            _restaurantService = restaurantService;
            _clientService = clientService;
            _bookingService = bookingService;
        }

        public Restaurant CreateRestaurant(string name, string address, int totalTables, int? phone=null, string? description=null)
        {
            var restaurant = _restaurantService.AddRestaurant(name, address, totalTables, phone, description);
            Console.WriteLine($"Добавлен ресторан: {restaurant.Name}, по адресу: {restaurant.Address}");
            return restaurant;
        }

        public Client CreateClient(string name, long phone, string? email=null)
        {
            var client = _clientService.AddClient(name, phone, email);
            Console.WriteLine($"Добавлен клиент: {client.Name}, тел.: {client.Phone}");
            return client;
        }

        public Booking CreateBooking(int restaurantId, int clientId, string date, string time, int quantitiesClient)
        {
            var booking = _bookingService.CreateBooking(restaurantId, clientId, date, time, quantitiesClient);
            Console.WriteLine($"Добавлена бронь на дату: {booking.Date} {booking.Time}, кол-во: {booking.QuantitiesClient}");
            return booking;
        }

        public void CancelBooking(int bookingId)
        {
            _bookingService.CancelBooking(bookingId);
            Console.WriteLine($"Бронь номер {bookingId} отменена");
        }

        public void GetBooking(int bookingId)
        {
            var booking = _bookingService.GetBookingById(bookingId);
            if (booking == null)
                Console.WriteLine($"Бронь не найдена");
            else
                Console.WriteLine($"Бронь найдена: {booking.Date} {booking.Time}, статус - {booking.Status}");


        }

        public void RunDemo()
        {
            Console.WriteLine($"Запуск демонстрации работы...");
            var restaurant = CreateRestaurant("Чешуя", "г. Красноярск, ул. Ленина, дом 118а", 4);
            var client = CreateClient("Егор Максимов", 79244136969);
            var booking = CreateBooking(restaurant.Id, client.Id, "14.03.2025", "12:00", 8);
            
            GetBooking(booking.Id);
            CancelBooking(booking.Id);
            GetBooking(booking.Id);

            var booking1 = CreateBooking(restaurant.Id, client.Id, "14.03.2025", "12:00", 8);
            var booking2 = CreateBooking(restaurant.Id, client.Id, "14.03.2025", "12:00", 8);
            var booking3 = CreateBooking(restaurant.Id, client.Id, "14.03.2025", "12:00", 8);
            var booking4 = CreateBooking(restaurant.Id, client.Id, "14.03.2025", "12:00", 8);
        }
    }
}