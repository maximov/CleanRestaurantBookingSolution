using CleanRestaurantBooking.Domain.Entities;

namespace CleanRestaurantBooking.Application.Interfaces
{
    public interface IClientRepository
    {
        Client? GetById(int id);

        void Add(Client client);
        void Update(Client client);
        void Delete(int id);
        IEnumerable<Client> GetAll();
    }
}