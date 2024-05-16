using CapitalPlacement_Task1.Controllers.ViewModels;
using CapitalPlacement_Task1.Domain;
using CapitalPlacement_Task1.Services.Interfaces.Repository;
using CapitalPlacement_Task1.Services.Interfaces.Service;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;

namespace CapitalPlacement_Task1.Services;

public class GetProgramService : IGetProgramService
{
    private readonly IProgramRepository _programRepository;

    public GetProgramService(IProgramRepository programRepository)
    {
        _programRepository = programRepository;
    }
    public async Task<ProgramVm> GetProgram(string id)
    {
        var result =  await _programRepository.GetById(id);
        if (result is not null)
        {
            return new ProgramVm
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Application = new ApplicationVm
                {
                    Fields = result.Application.Fields.Select(f => new FieldVm
                    {
                        Id = f.Id,
                        IsMandatory = f.IsMandatory,
                        Text = f.Text,
                        AnswerType = Enum.GetName(typeof(AnswerType), f.AnswerType),


                    }).ToList(),
                    CustomQuestions = result.Application.CustomQuestions.Select(cq => new CustomQuestionVm
                    {
                        Id = cq.Id,
                        Text = cq.Text,
                        AnswerType = Enum.GetName(typeof(AnswerType), cq.AnswerType),
                        Choices = cq.Choices,
                        QuestionType = Enum.GetName(typeof(QuestionType), cq.Type),
                    }).ToList(),
                }
            };
        }
        return null;
    }

}
