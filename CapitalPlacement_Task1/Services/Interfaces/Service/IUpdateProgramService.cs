
using CapitalPlacement_Task1.Controllers.Requests;

namespace CapitalPlacement_Task1.Services.Interfaces.Service;

public interface IUpdateProgramService
{
    Task<Domain.Program> UpdateProgram(UpdateProgramRequest request);
}
