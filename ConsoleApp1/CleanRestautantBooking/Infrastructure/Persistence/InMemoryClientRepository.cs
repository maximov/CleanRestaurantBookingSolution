using CleanRestaurantBooking.Domain.Entities;
using CleanRestaurantBooking.Application.Interfaces;
using System.Linq;

namespace CleanRestaurantBooking.Infrastructure.Persistence
{
    public class InMemoryClientRepository : IClientRepository
    {
        private readonly Dictionary<int, Client> _client = new();

        public Client Add(Client client)
        {
            if (_client.ContainsKey(client.Id))
                throw new InvalidOperationException("Клиент уже добавлен");

            _client[client.Id] = client;
            return client;
        }

        public void Delete(int id)
        {
            if (!_client.ContainsKey(id))
                throw new InvalidOperationException("Клиент не существует");
                
            _client.Remove(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _client.Values;
        }

        public Client? GetById(int id)
        {
            return _client[id];
        }

        public void Update(Client client)
        {
            if (!_client.ContainsKey(client.Id))
                throw new InvalidOperationException("Клиент не найден для обновления");

            _client[client.Id] = client;
        }
    }
}