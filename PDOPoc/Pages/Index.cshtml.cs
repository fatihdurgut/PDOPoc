using Azure.Data.Tables;
using Medienstudio.Azure.Data.Tables.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PDOPoc.Model;

namespace PDOPoc.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private const string TableName = "EmployeeReceipt";
        private readonly IConfiguration _configuration;
        private TableClient tableClient;
        public List<ReceiptItemEntity> ReceiptItems { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;           
        }

        private async Task GetTableClient()
        {

            TableServiceClient tableServiceClient = new(_configuration["StorageConnectionString"]);
            tableClient = tableServiceClient.GetTableClient(TableName);
            await tableClient.CreateIfNotExistsAsync();

        }

        public async Task<List<ReceiptItemEntity>> GetAllRows()
        {            
            List<ReceiptItemEntity> entities = await tableClient.GetAllEntitiesAsync<ReceiptItemEntity>();
            return entities;
        }


        public async Task OnGet()
        {
            await GetTableClient();
            ReceiptItems = await GetAllRows();
        }
    }
}