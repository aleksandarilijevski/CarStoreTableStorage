using Azure;
using Azure.Data.Tables;
using CarStoreTableStorage.Enums;

namespace CarStoreTableStorage.Models
{
    public class Car : ITableEntity
    {
        public string PartitionKey { get; set; }

        public string RowKey { get; set; }

        public DateTimeOffset? Timestamp { get; set; }

        public ETag ETag { get; set; }

        public string Model { get; set; }

        public int YearOfManufacture { get; set; }

        public FuelType FuelType { get; set; }

        public decimal Price { get; set; }
    }
}
