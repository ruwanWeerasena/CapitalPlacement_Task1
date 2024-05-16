
using CapitalPlacement_Task1.Controllers.Requests;
using CapitalPlacement_Task1.Controllers.ViewModels;
using CapitalPlacement_Task1.Domain;
using CapitalPlacement_Task1.Services.Interfaces.Repository;
using CapitalPlacement_Task1.Services;
using FakeItEasy;
using FluentAssertions;

namespace CapitalPlacement_Task1_Test.Services;

public class CreateProgramServiceTests
{
    private readonly IProgramRepository _programRepository;

    public CreateProgramServiceTests()
    {
        _programRepository = A.Fake<IProgramRepository>();
    }

    [Fact]
    public async void CreateProgramService_CreateProgram_ReturnProgramVm()
    {
        //arrange


        var program = new Program
        {
            Id = "8b7a31db-e373-40b4-a2ec-912bf7d8f438",
            Title = "test",
            Description = "test",
            Application = new Application
            {
                Fields = new List<Field>
                {
                    new Field
                    {
                        Id="c9a1a6ed-0e75-46f8-8b7f-a73e67be3542",
                        Text="test",
                        IsMandatory=true,
                        AnswerType= AnswerType.Number
                    }
                },
                CustomQuestions = new List<CustomQuestion>
                {
                    new CustomQuestion
                    {
                        Id="e91a7e34-ca04-442e-9246-190b3c7d778e",
                        Text="helloo",
                        Type = QuestionType.Paragraph,
                        Choices = null,
                        AnswerType = AnswerType.Number
                    }
                }
            }
        };
        var createProgramRequest = new CreateProgramRequest
        {

            Title = "test",
            Description = "test",
            ApplicationRequest = new ApplicationRequest
            {
                FieldRequests = new List<FieldRequest>()
                {
                    new FieldRequest {
                        Text="test",
                        IsMandatory=true,
                        AnswerType= AnswerType.Number
                    }

                },
                CustomQuestionRequests = new List<CustomQuestionRequest>()
                {
                    new CustomQuestionRequest{
                       Text="test",
                        QuestionType=QuestionType.Dropdown,
                        Choices=null,
                        AnswerType= AnswerType.Number
                    }
                }
            }
        };

        A.CallTo(() => _programRepository.Create(A<Program>._)).Returns(program);

        var service = new CreateProgramService(_programRepository);

        //act
        var result = await service.CreateProgram(createProgramRequest);

        //assert

        result.Should().NotBeNull();
        result.Should().BeOfType<ProgramVm>();
    }
}
