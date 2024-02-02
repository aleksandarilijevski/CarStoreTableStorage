using CarStoreTableStorage.Models;

namespace CarStoreTableStorage.Services.Interfaces
{
    public interface ITableStorageService
    {
        public Task AddUser(User user);

        public Task AddCar(Car car);

        public Task<List<User>> GetAllUsers();

        public Task<List<Car>> GetAllCars();
    }
}
