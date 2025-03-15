using CleanRestaurantBooking.Domain.Entities;

namespace CleanRestaurantBooking.Application.Interfaces
{
    public interface IBookingRepository
    {
        Booking? GetById(int id, string? query=null);

        Booking Add(Booking booking, string? query=null);
        void Update(Booking booking, string? query=null);
        void Delete(int id, string? query=null);
        IEnumerable<Booking> GetBookingByRestAndDate(int restaurantId, string date, string? query=null);
        
    }
}