using CapitalPlacement_Task1.Services.Interfaces.Repository;
using CapitalPlacement_Task1.Services.Interfaces.Service;

namespace CapitalPlacement_Task1.Services;

public class GetProgramService : IGetProgramService
{
    private readonly IProgramRepository _programRepository;

    public GetProgramService(IProgramRepository programRepository)
    {
        _programRepository = programRepository;
    }
    public async Task<Domain.Program> GetProgram(string id)
    {
        return await _programRepository.GetById(id);
        
    }

}
