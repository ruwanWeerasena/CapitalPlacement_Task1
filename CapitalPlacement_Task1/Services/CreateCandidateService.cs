using CapitalPlacement_Task1.Controllers.Requests;
using CapitalPlacement_Task1.Domain;
using CapitalPlacement_Task1.Services.Interfaces.Repository;
using CapitalPlacement_Task1.Services.Interfaces.Service;
using System.Text.Json;

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
                Answer = JsonSerializer.Serialize(qa.Answer)

            }).ToList(),
        };
        var result = await _candidateRepository.Create(candidate);
        if (result is not null)
        {
            foreach (CustomQuestionAnswer cqa in result.CustomQuestionAnswers)
            {
                CustomQuestion question = program.Application.CustomQuestions.FirstOrDefault(cq => cq.Id == cqa.CustomQuestionId);
                switch (question.AnswerType)
                {
                    case 0:
                        cqa.Answer = JsonSerializer.Deserialize<string>(cqa.Answer.ToString()); break;
                    case (AnswerType)1:
                        cqa.Answer = JsonSerializer.Deserialize<bool>(cqa.Answer.ToString()); break;
                    case (AnswerType)2:
                        cqa.Answer = DateOnly.Parse(JsonSerializer.Deserialize<string>(cqa.Answer.ToString())); break;
                    case (AnswerType)3:
                        cqa.Answer = JsonSerializer.Deserialize<List<string>>(cqa.Answer.ToString()); break;
                    case (AnswerType)4:
                        cqa.Answer = JsonSerializer.Deserialize<int>(cqa.Answer.ToString()); break;
                }
            }

            return result;
        }
        return null;
    }

}
