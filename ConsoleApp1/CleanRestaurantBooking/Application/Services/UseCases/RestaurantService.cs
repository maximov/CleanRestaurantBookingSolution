using CleanRestaurantBooking.Domain.Entities;
using CleanRestaurantBooking.Application.Interfaces;
using System.Linq;

namespace CleanRestaurantBooking.Application.Services
{
    public class RestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private int _currentRestarauntId = 1;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public Restaurant AddRestaurant(string name, string address, int totalTables, int? phone=null, string? description=null)
        {
            // добавить проверку существования ресторана
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название ресторана не может быть пустым");
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Адрес ресторана не может быть пустым");
            if (totalTables < 0)
                throw new ArgumentException("Количество столов не может быть меньше нуля");

            var newRestaurant = new Restaurant(
                _currentRestarauntId++,
                name,
                address,
                totalTables,
                phone,
                description
                );

            _restaurantRepository.Add(newRestaurant);
            return newRestaurant;
        }

        public void UpdateRestaurant(int restaurantId, string? newName=null, string? newAddress=null, int? newTotalTables=null, int? newPhone=null, string? newDescription=null)
        {
            var restaurant = _restaurantRepository.GetById(restaurantId) ?? 
                throw new InvalidOperationException("Ресторан не найден");

            bool isUpdate = false;
            
            if (!string.IsNullOrWhiteSpace(newName))
                restaurant.UpdateName(newName);
                isUpdate = true;

            if (newTotalTables != null && newTotalTables >= 0)
                restaurant.UpdateTotalTables( newTotalTables.GetValueOrDefault(0));
                isUpdate = true;
            
            if (isUpdate)
                _restaurantRepository.Update(restaurant);
        }

        public Restaurant? GetRestaurantById(int restaurantId)
        {
            return _restaurantRepository.GetById(restaurantId);
        }

        public IEnumerable<Restaurant> GetAllRestaurant()
        {
            return _restaurantRepository.GetAll();
        }

        public Restaurant DeleteRestaurantById(int restaurantId)
        {
            var restaurant = _restaurantRepository.GetById(restaurantId);
            if (restaurant != null)
            {
                _restaurantRepository.Delete(restaurantId);
                return restaurant;
            }
            throw new InvalidOperationException("Ресторан не найден");
        }
    }
}