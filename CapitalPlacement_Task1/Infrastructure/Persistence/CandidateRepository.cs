using CapitalPlacement_Task1.Domain;
using CapitalPlacement_Task1.Services.Interfaces.Repository;
using Microsoft.Azure.Cosmos;

namespace CapitalPlacement_Task1.Infrastructure.Persistence;

public class CandidateRepository : ICandidateRepository
{
    private readonly IConfiguration _configuration;
    private readonly DbContext _dbContext;
    private readonly Container _container;
    public CandidateRepository(IConfiguration configuration, DbContext dbContext)
    {

        _configuration = configuration;
        _dbContext = dbContext;
        Database database = _dbContext.Client.GetDatabase(_configuration.GetSection("DatabaseId").Value);
        database.CreateContainerIfNotExistsAsync(id: "Candidate", partitionKeyPath: "/id").Wait();
        _container = database.GetContainer("Candidate");
    }
    public async Task<Candidate> Create(Candidate candidate)
    {
        try
        {
            ItemResponse<Candidate> response = await _container.UpsertItemAsync<Candidate>(item: candidate);
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
            ItemResponse<Candidate> response = await _container.DeleteItemAsync<Candidate>(id, new PartitionKey(id));
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<Candidate> GetById(string id)
    {
        try
        {
            ItemResponse<Candidate> response = await _container.ReadItemAsync<Candidate>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<Candidate> Update(Candidate candidate)
    {
        try
        {
            ItemResponse<Candidate> response = await _container.UpsertItemAsync<Candidate>(item: candidate);
            return response.Resource;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
