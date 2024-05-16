
using CapitalPlacement_Task1.Controllers.Requests;
using CapitalPlacement_Task1.Controllers.ViewModels;
using CapitalPlacement_Task1.Domain;
using CapitalPlacement_Task1.Services.Interfaces.Repository;
using CapitalPlacement_Task1.Services.Interfaces.Service;

namespace CapitalPlacement_Task1.Services;
public class UpdateProgramService: IUpdateProgramService
{
    private readonly IProgramRepository _programRepository;

    public UpdateProgramService(IProgramRepository programRepository)
    {
        _programRepository = programRepository;
    }
    public async Task<ProgramVm> UpdateProgram(UpdateProgramRequest request)
    {
        var newProgram = new Domain.Program
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
            Application = new Domain.Application
            {
                Fields = request.ApplicationRequest.FieldRequests.Select(fr => new Field
                {
                    Id = fr.Id,
                    Text = fr.Text,
                    IsMandatory = fr.IsMandatory,
                    AnswerType = fr.AnswerType,
                }).ToList(),
                CustomQuestions = request.ApplicationRequest.CustomQuestionRequests.Select(cq => new CustomQuestion
                {
                    Id = cq.Id,
                    Text = cq.Text,
                    Type = cq.QuestionType,
                    Choices = cq.Choices,
                    AnswerType = cq.AnswerType
                }).ToList()
            }
        };
        var result = await _programRepository.Update(newProgram);
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
