using CleanRestaurantBooking.Domain.Entities;
using CleanRestaurantBooking.Application.Interfaces;
using CleanRestaurantBooking.Application.Services;
using CleanRestaurantBooking.Infrastructure.Persistence;
using CleanRestaurantBooking.ConsoleUI.Controller;

var restaurantRepository = new InMemoryRestaurantRepository();
var clientRepository = new InMemoryClientRepository();
var bookingRepository = new InMemoryBookingRepository();

var restaurantService = new RestaurantService(restaurantRepository);
var clientService = new ClientService(clientRepository);
var bookingService = new BookingService(bookingRepository, restaurantRepository, clientRepository);

var mainController = new MainController(restaurantService, clientService, bookingService);
mainController.RunDemo();