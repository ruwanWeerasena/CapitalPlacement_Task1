using CapitalPlacement_Task1.Controllers.Requests;
using CapitalPlacement_Task1.Controllers.ViewModels;

namespace CapitalPlacement_Task1.Services.Interfaces.Service;

public interface ICreateProgramService
{
    Task<ProgramVm> CreateProgram(CreateProgramRequest request);
}
