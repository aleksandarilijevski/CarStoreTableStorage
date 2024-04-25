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
            Console.WriteLine("7.Get user by GUID");
            Console.WriteLine("8.Get car by GUID");
            Console.WriteLine("9.Get user by column data");
            Console.WriteLine("10.Get car by column data");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("11.Delete user");
            Console.WriteLine("12.Delete car");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("13.Add balance");
            Console.WriteLine("14.Sell car");
            Console.WriteLine("15.Exit");
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
                        await AddUser();
                        break;

                    case MenuOptions.AddCar:
                        Console.Clear();
                        await AddCar();
                        break;

                    case MenuOptions.EditUser:
                        Console.Clear();
                        await EditUser();
                        break;

                    case MenuOptions.EditCar:
                        Console.Clear();
                        await EditCar();
                        break;

                    case MenuOptions.GetAllUsers:
                        Console.Clear();
                        await GetAllUsers();
                        break;

                    case MenuOptions.GetAllCars:
                        Console.Clear();
                        await GetAllCars();
                        break;

                    case MenuOptions.GetUserByID:
                        Console.Clear();
                        await GetUserByGUID();
                        break;

                    case MenuOptions.GetCarByID:
                        Console.Clear();
                        await GetCarByGUID();
                        break;

                    case MenuOptions.GetUserByColumnData:
                        Console.Clear();
                        await GetUserByColumnData();
                        break;

                    case MenuOptions.GetCarByColumnData:
                        Console.Clear();
                        await GetCarByColumnData();
                        break;

                    case MenuOptions.DeleteUser:
                        Console.Clear();
                        await DeleteUser();
                        break;

                    case MenuOptions.DeleteCar:
                        Console.Clear();
                        await DeleteCar();
                        break;

                    case MenuOptions.AddBalance:
                        Console.Clear();
                        await AddBalance();
                        break;

                    case MenuOptions.SellCar:
                        Console.Clear();
                        await SellCar();
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

        public async Task AddUser()
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

            Console.Write("Balance : ");
            double balance = double.Parse(Console.ReadLine());

            Console.Clear();

            User user = new User
            {
                RowKey = Guid.NewGuid().ToString(),
                FirstAndLastName = nameAndLastName,
                DateOfBirth = DateTime.SpecifyKind(dateOfBirth, DateTimeKind.Utc),
                JMBG = jmbg,
                Balance = balance
            };

            await _storageService.AddUser(user);

            Console.WriteLine("User was successfully created!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public async Task AddCar()
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

            Console.Write("Price : ");
            double price = double.Parse(Console.ReadLine());

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
                RowKey = Guid.NewGuid().ToString(),
                Brand = brand,
                Model = model,
                YearOfManufacture = yearOfManufacture,
                FuelType = fuelType,
                Price = price
            };

            await _storageService.AddCar(car);

            Console.WriteLine("Car was successfully created!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public async Task EditUser()
        {
            Console.Write("Enter GUID of the user you want to edit : ");
            string guid = Console.ReadLine();

            User user = await _storageService.GetUserByGUID(guid);

            if (user is null)
            {
                Console.WriteLine("User with entered GUID does not exist!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Console.Clear();

            Console.Write("Name and lastname : ");
            string nameAndLastName = Console.ReadLine();

            Console.Clear();

            Console.Write("Date of birth (1/1/2024) : ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Clear();

            Console.Write("JMBG : ");
            long jmbg = long.Parse(Console.ReadLine());

            Console.Clear();

            Console.Write("Balance : ");
            double balance = double.Parse(Console.ReadLine());

            Console.Clear();

            user.FirstAndLastName = nameAndLastName;
            user.DateOfBirth = DateTime.SpecifyKind(dateOfBirth, DateTimeKind.Utc);
            user.JMBG = jmbg;
            user.Balance = balance;

            await _storageService.EditUser(user);

            Console.WriteLine("User was successfully updated!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public async Task EditCar()
        {
            FuelType fuelType;

            Console.Write("Enter GUID of the user you want to edit : ");
            string guid = Console.ReadLine();

            Car car = await _storageService.GetCarByGUID(guid);

            if (car is null)
            {
                Console.WriteLine("Car with entered GUID does not exist!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Console.Clear();

            Console.Write("Brand : ");
            string brand = Console.ReadLine();

            Console.Clear();

            Console.Write("Model : ");
            string model = Console.ReadLine();

            Console.Clear();

            Console.Write("Year of manufacture : ");
            int yearOfManufacture = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.Write("Price : ");
            double price = double.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("1.Gas");
            Console.WriteLine("2.Diesel");
            Console.WriteLine("3.Gasoline");
            Console.WriteLine("4.Electrical");
            Console.Write("Fuel type : ");
            Enum.TryParse(Console.ReadLine(), out fuelType);

            Console.Clear();

            car.Brand = brand;
            car.Model = model;
            car.YearOfManufacture = yearOfManufacture;
            car.Price = price;
            car.FuelType = fuelType;

            await _storageService.EditCar(car);

            Console.WriteLine("Car was successfully updated!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private async Task GetAllUsers()
        {
            List<User> users = await _storageService.GetAllUsers();

            if (users.Count == 0)
            {
                Console.WriteLine("There is no users to be displayed!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("=================================");

            foreach (User user in users)
            {
                Console.WriteLine("GUID : " + user.RowKey);
                Console.WriteLine("First and lastname : " + user.FirstAndLastName);
                Console.WriteLine("Date of birth : " + user.DateOfBirth.ToString());
                Console.WriteLine("JMBG : " + user.JMBG);
                Console.WriteLine("Balance : " + user.Balance.ToString("0.00"));
                Console.WriteLine("=================================");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private async Task GetAllCars()
        {
            List<Car> cars = await _storageService.GetAllCars();

            if (cars.Count == 0)
            {
                Console.WriteLine("There is no cars to be displayed!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("=================================");

            foreach (Car car in cars)
            {
                Console.WriteLine("GUID : " + car.RowKey);
                Console.WriteLine("Brand : " + car.Brand);
                Console.WriteLine("Model : " + car.Model);
                Console.WriteLine("Year Of Manufacture : " + car.YearOfManufacture);
                Console.WriteLine("Fuel Type : " + car.FuelType);
                Console.WriteLine("Price : " + car.Price.ToString("0.00"));
                Console.WriteLine("=================================");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public async Task GetUserByGUID()
        {
            Console.Write("Enter user GUID : ");
            string guid = Console.ReadLine();

            Console.Clear();

            User user = await _storageService.GetUserByGUID(guid);

            if (user is null)
            {
                Console.WriteLine("User with entered GUID does not exist!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("=================================");
            Console.WriteLine("GUID : " + user.RowKey);
            Console.WriteLine("First and lastname : " + user.FirstAndLastName);
            Console.WriteLine("Date of birth : " + user.DateOfBirth.ToString());
            Console.WriteLine("JMBG : " + user.JMBG);
            Console.WriteLine("Balance : " + user.Balance.ToString("0.00"));
            Console.WriteLine("=================================");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public async Task GetCarByGUID()
        {
            Console.Write("Enter car GUID : ");
            string guid = Console.ReadLine();

            Console.Clear();

            Car car = await _storageService.GetCarByGUID(guid);

            if (car is null)
            {
                Console.WriteLine("Car with entered GUID does not exist!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("=================================");
            Console.WriteLine("GUID : " + car.RowKey);
            Console.WriteLine("Brand : " + car.Brand);
            Console.WriteLine("Model : " + car.Model);
            Console.WriteLine("Year Of Manufacture : " + car.YearOfManufacture);
            Console.WriteLine("Fuel Type : " + car.FuelType);
            Console.WriteLine("Price : " + car.Price.ToString("0.00"));
            Console.WriteLine("=================================");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public async Task GetUserByColumnData()
        {
            Console.Write("Enter column name : ");
            string columnName = Console.ReadLine();

            Console.Clear();

            Console.Write("Enter column value : ");
            string columnValue = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Search by : ");
            Console.WriteLine("1.String");
            Console.WriteLine("2.Long");
            Console.WriteLine("3.Double");
            Console.WriteLine("4.Date");
            Console.Write("Option : ");
            int option = int.Parse(Console.ReadLine());

            Console.Clear();

            List<User> users = await _storageService.GetUserByColumnData(columnName, columnValue, option);

            if (users.Count == 0)
            {
                Console.WriteLine("There is no entities!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("=================================");

            foreach (User user in users)
            {
                Console.WriteLine("GUID : " + user.RowKey);
                Console.WriteLine("First and lastname : " + user.FirstAndLastName);
                Console.WriteLine("Date of birth : " + user.DateOfBirth.ToString());
                Console.WriteLine("JMBG : " + user.JMBG);
                Console.WriteLine("Balance : " + user.Balance.ToString("0.00"));
                Console.WriteLine("=================================");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public async Task GetCarByColumnData()
        {
            Console.Write("Enter column name : ");
            string columnName = Console.ReadLine();

            Console.Clear();

            Console.Write("Enter column value : ");
            string columnValue = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Search by : ");
            Console.WriteLine("1.String");
            Console.WriteLine("2.Int");
            Console.WriteLine("3.Double");
            Console.Write("Option : ");
            int option = int.Parse(Console.ReadLine());

            Console.Clear();

            List<Car> cars = await _storageService.GetCarByColumnData(columnName, columnValue, option);

            if (cars.Count == 0)
            {
                Console.WriteLine("There is no entities!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("=================================");

            foreach (Car car in cars)
            {
                Console.WriteLine("GUID : " + car.RowKey);
                Console.WriteLine("Brand : " + car.Brand);
                Console.WriteLine("Model : " + car.Model);
                Console.WriteLine("Year Of Manufacture : " + car.YearOfManufacture);
                Console.WriteLine("Fuel Type : " + car.FuelType);
                Console.WriteLine("Price : " + car.Price.ToString("0.00"));
                Console.WriteLine("=================================");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public async Task DeleteUser()
        {
            Console.Write("Enter user GUID : ");
            string guid = Console.ReadLine();

            Console.Clear();

            User user = await _storageService.GetUserByGUID(guid);

            if (user is null)
            {
                Console.WriteLine("User with entered GUID does not exist!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            await _storageService.DeleteUser(user);
            Console.WriteLine("User was successfully deleted!");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public async Task DeleteCar()
        {
            Console.Write("Enter car GUID : ");
            string guid = Console.ReadLine();

            Console.Clear();

            Car car = await _storageService.GetCarByGUID(guid);

            if (car is null)
            {
                Console.WriteLine("Car with entered GUID does not exist!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            await _storageService.DeleteCar(car);
            Console.WriteLine("Car was successfully deleted!");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public async Task AddBalance()
        {
            Console.Write("Enter user GUID : ");
            string guid = Console.ReadLine();

            Console.Clear();

            User user = await _storageService.GetUserByGUID(guid);

            if (user is null)
            {
                Console.WriteLine("User with entered GUID does not exist!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter the amount you want to add : ");
            double amount = double.Parse(Console.ReadLine());

            user.Balance += amount;
            await _storageService.EditUser(user);

            Console.Clear();

            Console.WriteLine("Amount of : " + amount + " have been added to balance!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public async Task SellCar()
        {
            Console.Write("Enter car guid : ");
            string carGuid = Console.ReadLine();

            Car car = await _storageService.GetCarByGUID(carGuid);

            if (car is null)
            {
                Console.WriteLine("Car with entered GUID does not exist!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Console.Clear();

            Console.Write("Enter user GUID : ");
            string userGuid = Console.ReadLine();

            User user = await _storageService.GetUserByGUID(userGuid);

            if (user is null)
            {
                Console.WriteLine("User with entered GUID does not exist!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Console.Clear();

            if (car.Price > user.Balance)
            {
                Console.WriteLine("User does not have enough balance to buy a car!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            user.Balance -= car.Price;
            await _storageService.EditUser(user);

            Console.WriteLine("Car was successfully sold to user!");
        }
    }
}
