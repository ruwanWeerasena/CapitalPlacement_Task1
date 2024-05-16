using CapitalPlacement_Task1.Controllers.ViewModels;

namespace CapitalPlacement_Task1.Services.Interfaces.Service;

public interface IGetProgramService
{
    Task<ProgramVm> GetProgram(string id);
}
