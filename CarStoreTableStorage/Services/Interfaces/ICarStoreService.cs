namespace CarStoreTableStorage.Services.Interfaces
{
    public interface ICarStoreService
    {
        public void MenuText();

        public Task Menu();

        public Task AddUser();

        public Task AddCar();
    }
}
