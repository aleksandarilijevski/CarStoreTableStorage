using CarStoreTableStorage.Services;
using CarStoreTableStorage.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CarStoreTableStorage
{
    public class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProviders = SetupServices();

            ICarStoreService carStoreService = serviceProviders.GetService<ICarStoreService>();
            carStoreService.Menu().GetAwaiter().GetResult();
        }

        public static IServiceProvider SetupServices()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<ICarStoreService, CarStoreService>()
                .AddSingleton<ITableStorageService, TableStorageService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}