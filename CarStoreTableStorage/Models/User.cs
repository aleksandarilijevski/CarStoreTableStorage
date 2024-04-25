using Azure;
using Azure.Data.Tables;

namespace CarStoreTableStorage.Models
{
    public class User : ITableEntity
    {
        public string RowKey { get; set; }

        public string PartitionKey { get; set; } = nameof(User);

        public DateTimeOffset? Timestamp { get; set; }

        public ETag ETag { get; set; }

        public string FirstAndLastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public long JMBG { get; set; }

        public double Balance { get; set; }
    }
}
