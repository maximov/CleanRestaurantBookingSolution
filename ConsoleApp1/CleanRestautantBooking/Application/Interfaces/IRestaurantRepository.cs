using CleanRestaurantBooking.Domain.Entities;

namespace CleanRestaurantBooking.Application.Interfaces
{
    public interface IRestaurantRepository
    {
        Restaurant? GetById(int id);

        void Add(Restaurant restaurant);
        void Update(Restaurant restaurant);
        void Delete(int id);

        IEnumerable<Restaurant> GetAll();
    }
}