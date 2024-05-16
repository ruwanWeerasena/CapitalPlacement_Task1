namespace CapitalPlacement_Task1.Services.Interfaces.Service;

public interface IGetProgramService
{
    Task<Domain.Program> GetProgram(string id);
}
