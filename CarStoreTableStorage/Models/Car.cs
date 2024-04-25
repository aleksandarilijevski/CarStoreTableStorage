using Azure;
using Azure.Data.Tables;
using CarStoreTableStorage.Enums;

namespace CarStoreTableStorage.Models
{
    public class Car : ITableEntity
    {
        public string RowKey { get; set; }

        public string PartitionKey { get; set; } = nameof(Car);

        public DateTimeOffset? Timestamp { get; set; }

        public ETag ETag { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int YearOfManufacture { get; set; }

        public FuelType FuelType { get; set; }

        public double Price { get; set; }
    }
}
