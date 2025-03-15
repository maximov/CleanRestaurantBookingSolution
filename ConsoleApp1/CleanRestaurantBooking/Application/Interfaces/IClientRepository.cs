using CleanRestaurantBooking.Domain.Entities;

namespace CleanRestaurantBooking.Application.Interfaces
{
    public interface IClientRepository
    {
        Client? GetById(int id, string? query=null);

        void Add(Client client, string? query=null);
        void Update(Client client, string? query=null);
        void Delete(int id, string? query=null);
        IEnumerable<Client> GetAll(string? query=null);
    }
}