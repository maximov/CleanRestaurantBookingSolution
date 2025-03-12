using CleanRestaurantBooking.Domain.Entities;
using CleanRestaurantBooking.Application.Interfaces;
using System.Linq;

namespace CleanRestaurantBooking.Application.Services
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private int _currentBookingId = 1;

        public Booking CreateBooking(int restaurantId, int clientId, 
                    string date, string time)
                {
                    var restaurant = _restaurantRepository.GetById(restaurantId);
                    if (restaurant == null)
                        throw new Exception("Ресторан не найден");
                    
                }
    }
}