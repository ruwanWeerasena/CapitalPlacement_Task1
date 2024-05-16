using Microsoft.Azure.Cosmos;

namespace CapitalPlacement_Task1.Infrastructure;

public class DbContext
{
    private readonly IConfiguration _configuration;
    public CosmosClient Client { get; set; }

    public DbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        IConfigurationSection cosmosDbSection = _configuration.GetSection("CosmosDb");
        Client = new(accountEndpoint: cosmosDbSection.GetValue<string>("URL"), authKeyOrResourceToken: cosmosDbSection.GetValue<string>("PrimaryKey"));
        BuildCollection().Wait();
    }
    private async Task BuildCollection()
    {
        await Client.CreateDatabaseIfNotExistsAsync(_configuration.GetSection("DatabaseId").Value);

    }
}
