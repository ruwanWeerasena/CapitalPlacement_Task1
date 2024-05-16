

namespace CapitalPlacement_Task1.Services.Interfaces.Repository;

public interface IProgramRepository
{
    Task<Domain.Program> Create(Domain.Program program);
    Task<Domain.Program> Update(Domain.Program program);
    Task<Domain.Program> GetById(string id);
    Task<bool> Delete(string id);
}
