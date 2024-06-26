﻿using CapitalPlacement_Task1.Controllers.Requests;
using CapitalPlacement_Task1.Controllers.ViewModels;
using CapitalPlacement_Task1.Domain;
using CapitalPlacement_Task1.Services.Interfaces.Repository;
using CapitalPlacement_Task1.Services.Interfaces.Service;

namespace CapitalPlacement_Task1.Services;

public class CreateProgramService : ICreateProgramService
{
    private readonly IProgramRepository _programRepository;

    public CreateProgramService(IProgramRepository programRepository)
    {
        _programRepository = programRepository;
    }

    public async Task<ProgramVm> CreateProgram(CreateProgramRequest request)
    {
        var program = new Domain.Program
        {
            Id = Guid.NewGuid().ToString(),
            Title = request.Title,
            Description = request.Description,
            Application = new Application
            {
                Fields = request.ApplicationRequest.FieldRequests.Select(fr => new Field
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = fr.Text,
                    IsMandatory = fr.IsMandatory,
                    AnswerType = fr.AnswerType,
                }).ToList(),
                CustomQuestions = request.ApplicationRequest.CustomQuestionRequests.Select(cq => new CustomQuestion
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = cq.Text,
                    Type = cq.QuestionType,
                    Choices = cq.Choices,
                    AnswerType = cq.AnswerType
                }).ToList()
            }
        };


        var result = await _programRepository.Create(program);
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
