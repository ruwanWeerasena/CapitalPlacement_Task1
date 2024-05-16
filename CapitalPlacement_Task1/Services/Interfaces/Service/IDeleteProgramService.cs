using System.Threading.Tasks;

namespace CapitalPlacement_Task1.Services.Interfaces.Service;

public interface IDeleteProgramService
{
    Task<bool> DeleteProgram(string id);
}
