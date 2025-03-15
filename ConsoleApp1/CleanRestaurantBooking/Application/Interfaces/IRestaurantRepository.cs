using CleanRestaurantBooking.Domain.Entities;

namespace CleanRestaurantBooking.Application.Interfaces
{
    public interface IRestaurantRepository
    {
        Restaurant? GetById(int id, string? query=null);

        void Add(Restaurant restaurant, string? query=null);
        void Update(Restaurant restaurant, string? query=null);
        void Delete(int id, string? query=null);

        IEnumerable<Restaurant> GetAll(string? query=null);
    }
}