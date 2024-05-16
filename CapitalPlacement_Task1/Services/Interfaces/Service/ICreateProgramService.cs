using CapitalPlacement_Task1.Controllers.Requests;

namespace CapitalPlacement_Task1.Services.Interfaces.Service;

public interface ICreateProgramService
{
    Task<Domain.Program> CreateProgram(CreateProgramRequest request);
}
