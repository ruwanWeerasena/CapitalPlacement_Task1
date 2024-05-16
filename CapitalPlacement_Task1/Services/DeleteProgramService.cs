using CapitalPlacement_Task1.Services.Interfaces.Repository;
using CapitalPlacement_Task1.Services.Interfaces.Service;

namespace CapitalPlacement_Task1.Services;

public class DeleteProgramService : IDeleteProgramService
{
    private readonly IProgramRepository _programRepository;

    public DeleteProgramService(IProgramRepository programRepository)
    {
        _programRepository = programRepository;
    }

    public async Task<bool> DeleteProgram(string id)
    {
        return await _programRepository.Delete(id);
        
    }
}
