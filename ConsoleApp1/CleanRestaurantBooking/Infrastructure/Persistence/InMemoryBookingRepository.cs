using CleanRestaurantBooking.Domain.Entities;
using CleanRestaurantBooking.Application.Interfaces;
using System.Linq;

namespace CleanRestaurantBooking.Infrastructure.Persistence
{
    public class InMemoryBookingRepository //: IBookingRepository
    {
        private readonly Dictionary<int, Booking> _booking = new();

        public Booking Add(Booking booking)
        {
            if (_booking.ContainsKey(booking.Id))
                throw new InvalidOperationException("Бронь уже добавлена");

            _booking[booking.Id] = booking;
            return booking;
        }

        public void Delete(int id)
        {
            if (!_booking.ContainsKey(id))
                throw new InvalidOperationException("Бронь не существует");
                
            _booking.Remove(id);
        }

        public IEnumerable<Booking> GetBookingByRestAndDate(int restaurantId, string date)
        {
            return _booking.Values.Where(b => b.RestaurantId == restaurantId && b.Date == date);
        }

        public Booking? GetById(int id)
        {
            return _booking[id];
        }

        public void Update(Booking booking)
        {
            if (!_booking.ContainsKey(booking.Id))
                throw new InvalidOperationException("Бронь не найдена для обновления");

            _booking[booking.Id] = booking;
        }
    }
}