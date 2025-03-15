using CleanRestaurantBooking.Domain.Entities;
using CleanRestaurantBooking.Application.Interfaces;
using System.Linq;
using Npgsql;

namespace CleanRestaurantBooking.Infrastructure.Persistence
{
    public class PgRestaurantRepository : IRestaurantRepository
    {
        private readonly PostgresConnectionPool _pool;

        public PgRestaurantRepository(PostgresConnectionPool pool)
        {
            _pool = pool;
        }

        public void Add(Restaurant restaurant, string query)
        {
            using var connection = _pool.AcquireConnection();
            using var command = new NpgsqlCommand(query, connection);

            command.Parameters.AddWithValue("id", restaurant.Id);
            command.Parameters.AddWithValue("name", restaurant.Name);
            command.Parameters.AddWithValue("address", restaurant.Address);
            command.Parameters.AddWithValue("total_tables", restaurant.TotalTables);

            command.ExecuteNonQuery();
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