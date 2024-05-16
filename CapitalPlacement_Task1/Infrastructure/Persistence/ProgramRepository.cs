using CapitalPlacement_Task1.Services.Interfaces.Repository;
using Microsoft.Azure.Cosmos;

namespace CapitalPlacement_Task1.Infrastructure.Persistence;

public class ProgramRepository : IProgramRepository
{
    private readonly IConfiguration _configuration;
    private readonly DbContext _dbContext;
    private readonly Container _container;

    public ProgramRepository(IConfiguration configuration, DbContext dbContext)
    {
        _configuration = configuration;

        _dbContext = dbContext;
        Database database = _dbContext.Client.GetDatabase(_configuration.GetSection("DatabaseId").Value);
        database.CreateContainerIfNotExistsAsync(id: "Program", partitionKeyPath: "/id").Wait();
        _container = database.GetContainer("Program");
    }
    public async Task<Domain.Program> Create(Domain.Program program)
    {
        try
        {
            ItemResponse<Domain.Program> response = await _container.UpsertItemAsync<Domain.Program>(item: program);
            return response.Resource;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<bool> Delete(string id)
    {
        try
        {
            ItemResponse<Domain.Program> response = await _container.DeleteItemAsync<Domain.Program>(id, new PartitionKey(id));
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<Domain.Program> GetById(string id)
    {
        try
        {
            ItemResponse<Domain.Program> response = await _container.ReadItemAsync<Domain.Program>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<Domain.Program> Update(Domain.Program program)
    {
        try
        {
            ItemResponse<Domain.Program> response = await _container.UpsertItemAsync<Domain.Program>(item: program);
            return response.Resource;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
