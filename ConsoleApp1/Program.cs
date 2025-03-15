using CleanRestaurantBooking.Domain.Entities;
using CleanRestaurantBooking.Application.Interfaces;
using CleanRestaurantBooking.Application.Services;
using CleanRestaurantBooking.Infrastructure.Persistence;
using CleanRestaurantBooking.ConsoleUI.Controller;

string connectionString = "Host=localhost;Username=postgres;Password=12;Database=booking_db";

var pool = new PostgresConnectionPool(connectionString, 5);

// var restaurantRepository = new InMemoryRestaurantRepository();
// var clientRepository = new InMemoryClientRepository();
// var bookingRepository = new InMemoryBookingRepository();

var restaurantRepository = new PgRestaurantRepository(pool);
//var clientRepository = new PgClientRepository(pool);
//var bookingRepository = new PgBookingRepository(pool);

//var restaurantService = new RestaurantService(restaurantRepository);
//var clientService = new ClientService(clientRepository);
//var bookingService = new BookingService(bookingRepository, restaurantRepository, clientRepository);

//var mainController = new MainController(restaurantService, clientService, bookingService);
//mainController.RunDemo();

var newRestaurant = new Restaurant(0, "Чешуя", "ул.", 15, 79244136969, "Ресторан для теста");
restaurantRepository.Add(newRestaurant, 
"INSERT INTO tbl_restaurant (name, address, total_tables, phone, description) VALUES (@name, @address, @total_tables, @phone, @description)");