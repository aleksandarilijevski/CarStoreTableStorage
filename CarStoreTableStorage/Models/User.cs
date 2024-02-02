using Azure;
using Azure.Data.Tables;

namespace CarStoreTableStorage.Models
{
    public class User : ITableEntity
    {
        public string PartitionKey { get; set; }

        public string RowKey { get; set; }

        public DateTimeOffset? Timestamp { get; set; }

        public ETag ETag { get; set; }

        public DateTime DateOfBirth { get; set; }

        public long JMBG { get; set; }

        public List<Car> OwnedCars { get; set; } = new List<Car>();
    }
}
