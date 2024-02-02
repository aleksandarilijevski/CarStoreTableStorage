using Azure;
using Azure.Data.Tables;
using CarStoreTableStorage.Models;
using CarStoreTableStorage.Services.Interfaces;
using Microsoft.WindowsAzure.Storage.Table;

namespace CarStoreTableStorage.Services
{
    public class TableStorageService : ITableStorageService
    {
        public string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=consoleappstorageaccount;AccountKey=kz3cwBKZJQqaH2apkavnnZYu5xhZ3dvDO09ykObLFhuQDOcyrI0oH+cogLR2n0k8UN2j0c0Uki5f+AStmjmV4w==;EndpointSuffix=core.windows.net";

        public async Task AddUser(User user)
        {
            TableClient tableClient = new TableClient(ConnectionString, "Users");
            await tableClient.AddEntityAsync(user);
        }

        public async Task AddCar(Car car)
        {
            TableClient tableClient = new TableClient(ConnectionString, "Cars");
            await tableClient.AddEntityAsync(car);
        }

        public async Task<List<User>> GetAllUsers()
        {
            TableClient tableClient = new TableClient(ConnectionString, "Users");
            AsyncPageable<User> data = tableClient.QueryAsync<User>();

            List<User> users = new List<User>();

            await foreach (User user in data)
            {
                users.Add(user);
            }

            return users;
        }

        public async Task<List<Car>> GetAllCars()
        {
            TableClient tableClient = new TableClient(ConnectionString, "Cars");
            AsyncPageable<Car> data = tableClient.QueryAsync<Car>();

            List<Car> cars = new List<Car>();

            await foreach (Car car in data)
            {
                cars.Add(car);
            }

            return cars;
        }
    }
}
