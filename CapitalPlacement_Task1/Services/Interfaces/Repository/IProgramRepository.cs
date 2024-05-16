using CapitalPlacement_Task1.Controllers.Requests;

namespace CapitalPlacement_Task1.Services.Interfaces.Repository;

public interface IProgramRepository
{
    Task<Domain.Program> Create(Domain.Program program);
}
