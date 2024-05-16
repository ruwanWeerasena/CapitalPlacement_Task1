
using CapitalPlacement_Task1.Controllers.Requests;
using CapitalPlacement_Task1.Controllers.ViewModels;
using CapitalPlacement_Task1.Domain;
using CapitalPlacement_Task1.Services.Interfaces.Repository;
using CapitalPlacement_Task1.Services;
using FakeItEasy;
using FluentAssertions;
namespace CapitalPlacement_Task1_Test.Services;

public class UpdateProgramServiceTests
{
    private readonly IProgramRepository _programRepository;
    public UpdateProgramServiceTests()
    {
        _programRepository = A.Fake<IProgramRepository>();
    }

    [Fact]
    public async void UpdateProgramService_UpdateProgram_ReturnsProgramVm()
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
        var updateProgramRequest = new UpdateProgramRequest
        {
            Id = "8b7a31db-e373-40b4-a2ec-912bf7d8f438",
            Title = "test",
            Description = "test",
            ApplicationRequest = new ApplicationUpdateRequest
            {
                FieldRequests = new List<FieldUpdateRequest>()
                {
                    new FieldUpdateRequest {
                        Id="c9a1a6ed-0e75-46f8-8b7f-a73e67be3542",
                        Text="test",
                        IsMandatory=true,
                        AnswerType= AnswerType.Number
                    }

                },
                CustomQuestionRequests = new List<CustomQuestionUpdateRequest>()
                {
                    new CustomQuestionUpdateRequest{
                        Id="e91a7e34-ca04-442e-9246-190b3c7d778e",
                       Text="test",
                        QuestionType=QuestionType.Dropdown,
                        Choices=null,
                        AnswerType= AnswerType.Number
                    }
                }
            }
        };

        A.CallTo(() => _programRepository.Update(A<Program>._)).Returns(program);

        var service = new UpdateProgramService(_programRepository);

        //act
        var result = await service.UpdateProgram(updateProgramRequest);
        result.Should().NotBeNull();
        result.Should().BeOfType<ProgramVm>();
    }
}
