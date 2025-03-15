using CleanRestaurantBooking.Domain.Entities;
using CleanRestaurantBooking.Application.Interfaces;
using System.Linq;

namespace CleanRestaurantBooking.Infrastructure.Persistence
{
    public class InMemoryRestaurantRepository : IRestaurantRepository
    {
          private readonly Dictionary<int, Restaurant> _restaurants = new();

        public void Add(Restaurant restaurant)
        {
            if (_restaurants.ContainsKey(restaurant.Id))
                throw new InvalidOperationException("Ресторан уже добавлен");

            _restaurants[restaurant.Id] = restaurant;
            //return restaurant;
        }

        public void Delete(int id)
        {
            if (!_restaurants.ContainsKey(id))
                throw new InvalidOperationException("Ресторан не существует");
                
            _restaurants.Remove(id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.Values;
        }

        public Restaurant? GetById(int id)
        {
            return _restaurants[id];
        }

        public void Update(Restaurant restaurant)
        {
            if (!_restaurants.ContainsKey(restaurant.Id))
                throw new InvalidOperationException("Ресторан не найден для обновления");

            _restaurants[restaurant.Id] = restaurant;
        }
    
    }
}