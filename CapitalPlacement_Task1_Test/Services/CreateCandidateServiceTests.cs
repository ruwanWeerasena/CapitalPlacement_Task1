
using CapitalPlacement_Task1.Controllers.Requests;
using CapitalPlacement_Task1.Domain;
using CapitalPlacement_Task1.Services.Interfaces.Repository;
using CapitalPlacement_Task1.Services;
using FakeItEasy;
using FluentAssertions;

namespace CapitalPlacement_Task1_Test.Services;

public class CreateCandidateServiceTests
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly IProgramRepository _programRepository;

    public CreateCandidateServiceTests()
    {
        _candidateRepository = A.Fake<ICandidateRepository>();
        _programRepository = A.Fake<IProgramRepository>();
    }

    [Fact]
    public async void CreateCandidateService_CreateCandidate_ReturnCandidate()
    {
        //arrange

        var candidate = new Candidate
        {
            Id = "37cac4be-229e-407d-a889-0d336ca3509d",

            ProgramId = "8b7a31db-e373-40b4-a2ec-912bf7d8f438",
            FieldAnswers = new List<FieldAnswer>
            {
                new FieldAnswer
                {
                    Id="005da4ab-e571-4ee9-b42a-4ecfb6b139ee",
                    FieldId="c9a1a6ed-0e75-46f8-8b7f-a73e67be3542",
                    Answer="Ruwan2"
                }
                                                 },
            CustomQuestionAnswers = new List<CustomQuestionAnswer>
            {
                new CustomQuestionAnswer
                {
                    Id = "c87a6d61-5c45-4afc-b0ec-90cf9019f3db",
                    CustomQuestionId = "e91a7e34-ca04-442e-9246-190b3c7d778e",
                    Answer="20"
                }

            }
        };
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
        var createCandidateRequest = new CreateCandidateRequest
        {

            ProgramId = "8b7a31db-e373-40b4-a2ec-912bf7d8f438",
            FieldAnswers = new List<FieldAnswerRequest>()
            {
                    new FieldAnswerRequest {
                        FieldId="c9a1a6ed-0e75-46f8-8b7f-a73e67be3542",
                        Answer="Ruwan2"
                    }

            },
            CustomQuestionAnswers = new List<CustomQuestionAnswerRequest>()
            {
                    new CustomQuestionAnswerRequest{
                        CustomQuestionId="e91a7e34-ca04-442e-9246-190b3c7d778e",
                        Answer=20
                    }

            }
        };
        //var fakeCandidate = A.Fake<Candidate>();

        A.CallTo(() => _programRepository.GetById(createCandidateRequest.ProgramId)).Returns(program);
        A.CallTo(() => _candidateRepository.Create(A<Candidate>._)).Returns(candidate);
        var service = new CreateCandidateService(_candidateRepository, _programRepository);

        //act
        var result = await service.CreateCandidate(createCandidateRequest);

        //assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Candidate>();
    }
}
