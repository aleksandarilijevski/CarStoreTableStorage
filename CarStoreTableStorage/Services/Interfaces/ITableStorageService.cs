using CarStoreTableStorage.Models;

namespace CarStoreTableStorage.Services.Interfaces
{
    public interface ITableStorageService
    {
        public Task AddUser(User user);

        public Task AddCar(Car car);

        public Task EditUser(User user);

        public Task EditCar(Car car);

        public Task<List<User>> GetAllUsers();

        public Task<List<Car>> GetAllCars();

        public Task<User> GetUserByGUID(string guid);

        public Task<Car> GetCarByGUID(string guid);

        public Task<List<User>> GetUserByColumnData(string columnName, string columnValue, int option);

        public Task<List<Car>> GetCarByColumnData(string columnName, string columnValue, int option);

        public Task DeleteUser(User user);

        public Task DeleteCar(Car car);
    }
}
