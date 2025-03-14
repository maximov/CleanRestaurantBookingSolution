using CleanRestaurantBooking.Domain.Entities;
using CleanRestaurantBooking.Application.Interfaces;
using System.Linq;

namespace CleanRestaurantBooking.Application.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;
        private int _currentClientId = 1;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client AddClient(string name, long phone, string? email=null)
        {
            // todo Добавить проверку на уникальность
            // todo Добавить регулярку для email
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя не может быть пустым");

            if (phone > 0 && (phone.ToString().Length == 9 || phone.ToString().Length == 10))
                throw new ArgumentException("Номер указан некорректно");                
            
            var newClient = new Client(_currentClientId++, name, phone, email);
            _clientRepository.Add(newClient);

            return newClient;
        }

        public void UpdateClient(int clientId, string? newName=null, long? newPhone=null, string? newEmail=null)
        {
            var client = _clientRepository.GetById(clientId) ?? throw new InvalidOperationException("Клиент не найден");

            client.UpdateContactInfo(newName, newPhone, newEmail);
            _clientRepository.Update(client);

        }

        public void DeleteClient(int clientId)
        {
            if (_clientRepository.GetById(clientId) == null)  throw new InvalidOperationException("Клиент не найден");

            _clientRepository.Delete(clientId);
        }

        public Client? GetClientById(int clientId)
        {
            return _clientRepository.GetById(clientId);
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _clientRepository.GetAll();
        }

    }
}