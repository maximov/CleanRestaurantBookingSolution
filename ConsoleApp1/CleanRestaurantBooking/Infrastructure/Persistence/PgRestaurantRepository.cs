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

            command.Parameters.AddWithValue("phone", (object?)restaurant.Phone ?? DBNull.Value);
            command.Parameters.AddWithValue("description", (object?)restaurant.Description ?? DBNull.Value);

            command.ExecuteNonQuery();
        }

        public void Delete(int id, string query)
        {
            using var connection = _pool.AcquireConnection();
            using var command = new NpgsqlCommand(query, connection);

            command.Parameters.AddWithValue("id", id);

            command.ExecuteNonQuery();
        }

        public IEnumerable<Restaurant> GetAll(string query)
        {
            using var connection = _pool.AcquireConnection();
            using var command = new NpgsqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            var restaurants = new List<Restaurant>();

            while(reader.Read())
            {
                restaurants.Add(new Restaurant(
                    id: reader.GetInt32(0),
                    name: reader.GetString(1),
                    address: reader.GetString(2),
                    totalTables: reader.GetInt32(3),
                    phone: reader.GetInt64(4),
                    description: reader.GetString(5)
                    ));
            }
            return restaurants;
        }


        public Restaurant? GetById(int id, string query)
        {
            using var connection = _pool.AcquireConnection();
            using var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("id", id);

            using var reader = command.ExecuteReader();
            

            if(reader.Read())
            {
                return new Restaurant(
                    id: reader.GetInt32(0),
                    name: reader.GetString(1),
                    address: reader.GetString(2),
                    totalTables: reader.GetInt32(3),
                    phone: reader.GetInt64(4),
                    description: reader.GetString(5)
                    );
            }
            return null;
        }

        public void Update(Restaurant restaurant, string query)
        {
            using var connection = _pool.AcquireConnection();
            using var command = new NpgsqlCommand(query, connection);

            command.Parameters.AddWithValue("id", restaurant.Id);
            command.Parameters.AddWithValue("name", restaurant.Name);
            command.Parameters.AddWithValue("address", restaurant.Address);
            command.Parameters.AddWithValue("total_tables", restaurant.TotalTables);

            command.Parameters.AddWithValue("phone", (object?)restaurant.Phone ?? DBNull.Value);
            command.Parameters.AddWithValue("description", (object?)restaurant.Description ?? DBNull.Value);

            command.ExecuteNonQuery();
        }
    
    }
}