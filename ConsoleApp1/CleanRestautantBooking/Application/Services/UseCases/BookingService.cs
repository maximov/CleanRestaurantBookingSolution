using CleanRestaurantBooking.Domain.Entities;
using CleanRestaurantBooking.Application.Interfaces;
using System.Linq;

namespace CleanRestaurantBooking.Application.Services
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IClientRepository _clientRepository;
        private int _currentBookingId = 1;

        public Booking CreateBooking(int restaurantId, int clientId, 
                    string date, string time, int quantitiesClient)
                {
                    var restaurant = _restaurantRepository.GetById(restaurantId);
                    if (restaurant == null)
                        throw new Exception("Ресторан не найден");

                    var existingBooking = _bookingRepository.GetBookingByRestAndDate(restaurantId, date);

                    int count = existingBooking.Count();
                    if (!restaurant.HasFreeTables(count)){
                        throw new Exception("Все столики заняты на указанную дату");
                    }

                    var newBooking = new Booking(
                        id: _currentBookingId++,
                        clientId: clientId,
                        restaurantId: restaurantId,
                        date: date,
                        time: time,
                        quantitiesClient: quantitiesClient,
                        status: "Забронировано"
                    );

                    return _bookingRepository.Add(newBooking);
                }

        public void CancelBooking(int bookingId)
        {
            var booking = _bookingRepository.GetById(bookingId);
            if (booking == null)
                throw new InvalidOperationException("Бронь не найдена");
            
            booking.UpdateStatus("Отменено");
            _bookingRepository.Update(booking);
        }

        public void UpdateBookingTime(int bookingId, string newDate, string newTime)
        {
            var booking = _bookingRepository.GetById(bookingId);
            if (booking == null)
                throw new InvalidOperationException("Бронь не найдена");

            var restaurant = _restaurantRepository.GetById(booking.RestaurantId);
            if (restaurant == null)
                throw new InvalidOperationException("Ресторан не найден");

            // var existingBooking = _bookingRepository.GetBookingByRestAndDate(booking.RestaurantId, booking.Date).Where(b => b.Id != bookingId);
            booking.UpdateDateTime(newDate, newTime);
            _bookingRepository.Update(booking);
        }

        public void UpdateQuantitiesClient(int bookingId, int newQuantity)
        {
            var booking = _bookingRepository.GetById(bookingId);
            if (booking == null)
                throw new InvalidOperationException("Бронь не найдена");

            var restaurant = _restaurantRepository.GetById(booking.RestaurantId);
            if (restaurant == null)
                throw new InvalidOperationException("Ресторан не найден");

            var existingBooking = _bookingRepository.GetBookingByRestAndDate(booking.RestaurantId, booking.Date).Where(b => b.Id != bookingId);
            
            int bookedTablesCount = existingBooking.Sum(b => b.QuantitiesClient);

            if (!restaurant.HasFreeTables(bookedTablesCount + newQuantity))
                throw new InvalidOperationException("Недостаточно свободных мест на текущую дату");
            

            booking.UpdateQuantitiesClient(newQuantity);
            _bookingRepository.Update(booking);
        }

        public IEnumerable<Booking> GetBookingByDate(int restaurantId, string date)
        {
            return _bookingRepository.GetBookingByRestAndDate(restaurantId, date);
        }
    }
}