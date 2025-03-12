using CleanRestaurantBooking.Domain.Entities;

namespace CleanRestaurantBooking.Application.Interfaces
{
    public interface IBookingRepository
    {
        Booking? GetById(int id);

        Booking Add(Booking booking);
        void Update(Booking booking);
        void Delete(int id);
        IEnumerable<Booking> GetBookingByRestAndDate(int restaurantId, string date);
    }
}