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

        public async Task EditUser(User user)
        {
            TableClient tableClient = new TableClient(ConnectionString, "Users");
            await tableClient.UpdateEntityAsync<User>(user, ETag.All, TableUpdateMode.Replace);
        }

        public async Task EditCar(Car car)
        {
            TableClient tableClient = new TableClient(ConnectionString, "Cars");
            await tableClient.UpdateEntityAsync<Car>(car, ETag.All, TableUpdateMode.Replace);
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

        public async Task<User> GetUserByGUID(string guid)
        {
            TableClient tableClient = new TableClient(ConnectionString, "Users");

            string query = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, guid);
            AsyncPageable<User> data = tableClient.QueryAsync<User>(query);

            List<User> users = new List<User>();
            User user = null;

            await foreach (User userFind in data)
            {
                user = userFind;
            }

            return user;
        }

        public async Task<Car> GetCarByGUID(string guid)
        {
            TableClient tableClient = new TableClient(ConnectionString, "Cars");

            string query = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, guid);
            AsyncPageable<Car> data = tableClient.QueryAsync<Car>(query);

            List<Car> cars = new List<Car>();
            Car car = null;

            await foreach (Car carFind in data)
            {
                car = carFind;
            }

            return car;
        }

        public async Task<List<User>> GetUserByColumnData(string columnName, string columnValue, int option)
        {
            TableClient tableClient = new TableClient(ConnectionString, "Users");

            string query = string.Empty;

            switch (option)
            {
                case 1:
                    query = TableQuery.GenerateFilterCondition(columnName, QueryComparisons.Equal, columnValue);
                    break;

                case 2:
                    query = TableQuery.GenerateFilterConditionForLong(columnName, QueryComparisons.Equal, long.Parse(columnValue));
                    break;

                case 3:
                    query = TableQuery.GenerateFilterConditionForDouble(columnName, QueryComparisons.Equal, double.Parse(columnValue));
                    break;

                case 4:
                    DateTime dateTime = DateTime.Parse(columnValue);
                    DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, TimeSpan.Zero);
                    query = TableQuery.GenerateFilterConditionForDate(columnName, QueryComparisons.Equal, dateTimeOffset);
                    break;

                default:
                    return new List<User>();
                    break;
            }

            AsyncPageable<User> data = tableClient.QueryAsync<User>(query);

            List<User> users = new List<User>();

            await foreach (User userFind in data)
            {
                users.Add(userFind);
            }

            return users;
        }


        public async Task<List<Car>> GetCarByColumnData(string columnName, string columnValue, int option)
        {
            TableClient tableClient = new TableClient(ConnectionString, "Cars");

            string query = string.Empty;

            switch (option)
            {
                case 1:
                    query = TableQuery.GenerateFilterCondition(columnName, QueryComparisons.Equal, columnValue);
                    break;

                case 2:
                    query = TableQuery.GenerateFilterConditionForInt(columnName, QueryComparisons.Equal, int.Parse(columnValue));
                    break;

                case 3:
                    query = TableQuery.GenerateFilterConditionForDouble(columnName, QueryComparisons.Equal, double.Parse(columnValue));
                    break;

                case 4:
                    DateTime dateTime = DateTime.Parse(columnValue);
                    DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, TimeSpan.Zero);
                    query = TableQuery.GenerateFilterConditionForDate(columnName, QueryComparisons.Equal, dateTimeOffset);
                    break;

                default:
                    return new List<Car>();
                    break;
            }

            AsyncPageable<Car> data = tableClient.QueryAsync<Car>(query);

            List<Car> cars = new List<Car>();

            await foreach (Car carFind in data)
            {
                cars.Add(carFind);
            }

            return cars;
        }

        public async Task DeleteUser(User user)
        {
            TableClient tableClient = new TableClient(ConnectionString, "Users");
            await tableClient.DeleteEntityAsync(user.PartitionKey, user.RowKey);
        }

        public async Task DeleteCar(Car car)
        {
            TableClient tableClient = new TableClient(ConnectionString, "Cars");
            await tableClient.DeleteEntityAsync(car.PartitionKey, car.RowKey);
        }
    }
}
