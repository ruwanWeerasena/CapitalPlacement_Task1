using CapitalPlacement_Task1.Controllers.Requests;
using CapitalPlacement_Task1.Domain;
using CapitalPlacement_Task1.Services.Interfaces.Repository;
using CapitalPlacement_Task1.Services.Interfaces.Service;

namespace CapitalPlacement_Task1.Services;

public class CreateCandidateService : ICreateCandidateService
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly IProgramRepository _programRepository;

    public CreateCandidateService(ICandidateRepository candidateRepository, IProgramRepository programRepository)
    {
        _candidateRepository = candidateRepository;
        _programRepository = programRepository;
    }
    public async Task<Candidate> CreateCandidate(CreateCandidateRequest candidateRequest)
    {
        var program = await _programRepository.GetById(candidateRequest.ProgramId);
        var candidate = new Candidate
        {
            Id = Guid.NewGuid().ToString(),
            ProgramId = candidateRequest.ProgramId,
            FieldAnswers = candidateRequest.FieldAnswers.Select(fa => new FieldAnswer
            {
                Id = Guid.NewGuid().ToString(),
                FieldId = fa.FieldId,
                Answer = fa.Answer
            }).ToList(),
            CustomQuestionAnswers = candidateRequest.CustomQuestionAnswers.Select(qa => new CustomQuestionAnswer
            {
                Id = Guid.NewGuid().ToString(),
                CustomQuestionId = qa.CustomQuestionId,
                Answer = qa.Answer

            }).ToList(),
        };
        var result = await _candidateRepository.Create(candidate);
        return result;
    }
}
