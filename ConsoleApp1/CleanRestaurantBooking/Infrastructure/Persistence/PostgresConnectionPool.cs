using Npgsql;

namespace CleanRestaurantBooking.Infrastructure.Persistence
{
    public class PostgresConnectionPool
    {
        private readonly Queue<NpgsqlConnection> _connections = new();
        private readonly string _connectionString;
        private readonly object _lock = new();

        public PostgresConnectionPool(string connectionString, int poolSize)
        {
            _connectionString = connectionString;
            for (int i=0; i<poolSize; i++)
            {
                var connection = new NpgsqlConnection(_connectionString);
                _connections.Enqueue(connection);
            }
        }

        public NpgsqlConnection AcquireConnection()
        {
            lock (_lock)
            {
                if (_connections.Count == 0)
                    throw new InvalidOperationException("Нет доступных соединений");

                var connection = _connections.Dequeue();
                connection.Open();
                return connection;
            }
        }

        public void ReleaseConnection(NpgsqlConnection connection)
        {
            lock (_lock)
            {
                connection.Close();
                _connections.Enqueue(connection);
            }
        }
    }
}