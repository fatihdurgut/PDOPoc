using Azure;
using Azure.Data.Tables;
using System.Collections.Concurrent;

namespace PDOPoc.Model
{
    public class ReceiptItemEntity : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        public string MerchantAddress { get; set; }
        public string MerchantPhone { get; set;}
        public Int64 Total { get; set; }
    }
}
