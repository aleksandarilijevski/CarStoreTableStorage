using CarStoreTableStorage.Enums;
using CarStoreTableStorage.Models;
using CarStoreTableStorage.Services.Interfaces;

namespace CarStoreTableStorage.Services
{
    public class CarStoreService : ICarStoreService
    {
        private ITableStorageService _storageService;

        public CarStoreService(ITableStorageService storageService)
        {
            _storageService = storageService;
        }

        public void MenuText()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Add car");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("3. Edit user");
            Console.WriteLine("4. Edit car");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("5.Get all users");
            Console.WriteLine("6.Get all cars");
            Console.WriteLine("7.Get user by ID");
            Console.WriteLine("8.Get car by ID");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("9.Delete user");
            Console.WriteLine("10.Delete car");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("11.Sell car");
            Console.WriteLine("12.Exit");
            Console.WriteLine("-------------------------------");
            Console.Write("Option : ");
        }

        public async Task Menu()
        {
            MenuOptions menuOptions;

            do
            {
                Console.Clear();
                MenuText();
                Enum.TryParse(Console.ReadLine(), out menuOptions);

                switch (menuOptions)
                {
                    case MenuOptions.AddUser:
                        Console.Clear();
                        AddUser();
                        break;

                    case MenuOptions.AddCar:
                        Console.Clear();
                        AddCar();
                        break;

                    case MenuOptions.EditUser:
                        Console.Clear();
                        //await EditUser();
                        break;

                    case MenuOptions.EditCar:
                        Console.Clear();
                        //EditCar();
                        break;

                    case MenuOptions.GetAllUsers:
                        Console.Clear();
                        //await GetAllUsers();
                        break;

                    case MenuOptions.GetAllCars:
                        Console.Clear();
                        await GetAllCars();
                        break;

                    case MenuOptions.GetUserByID:
                        Console.Clear();
                        //await GetUserByID();
                        break;

                    case MenuOptions.GetCarByID:
                        Console.Clear();
                        //GetCarByID();
                        break;

                    case MenuOptions.DeleteUser:
                        Console.Clear();
                        //await DeleteUser();
                        break;

                    case MenuOptions.DeleteCar:
                        Console.Clear();
                        //DeleteCar();
                        break;

                    case MenuOptions.SellCar:
                        Console.Clear();
                        //await SellCar();
                        break;

                    case MenuOptions.Exit:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("That option does not exist!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                }

            } while (menuOptions != MenuOptions.Exit);
        }

        public void AddUser()
        {
            Console.Write("Name and lastname : ");
            string nameAndLastName = Console.ReadLine();

            Console.Clear();

            Console.Write("Date of birth (1/1/2024) : ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Clear();

            Console.Write("JMBG : ");
            long jmbg = long.Parse(Console.ReadLine());

            Console.Clear();

            User user = new User
            {
                //Temporary solution
                RowKey = "1",
                PartitionKey = nameAndLastName,
                DateOfBirth = DateTime.SpecifyKind(dateOfBirth, DateTimeKind.Utc),
                JMBG = jmbg
            };

            _storageService.AddUser(user);

            Console.WriteLine("User was successfully created!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public void AddCar()
        {
            FuelType fuelType;

            Console.Write("Brand : ");
            string brand = Console.ReadLine();

            Console.Clear();

            Console.Write("Model : ");
            string model = Console.ReadLine();

            Console.Clear();

            Console.Write("Year of manufacture : ");
            int yearOfManufacture = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("1.Gas");
            Console.WriteLine("2.Diesel");
            Console.WriteLine("3.Gasoline");
            Console.WriteLine("4.Electrical");
            Console.Write("Fuel type : ");
            Enum.TryParse(Console.ReadLine(), out fuelType);

            Console.Clear();

            Car car = new Car
            {
                //Temporary solution
                RowKey = "1",
                PartitionKey = brand,
                Model = model,
                YearOfManufacture = yearOfManufacture,
                FuelType = fuelType
            };

            _storageService.AddCar(car);

            Console.WriteLine("Car was successfully created!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private async Task GetAllCars()
        {
            List<Car> cars = await _storageService.GetAllCars();

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

    }
}
