
using CapitalPlacement_Task1.Controllers.Requests;
using CapitalPlacement_Task1.Controllers.ViewModels;
using CapitalPlacement_Task1.Controllers;
using CapitalPlacement_Task1.Domain;
using CapitalPlacement_Task1.Services.Interfaces.Service;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement_Task1_Test.Controllers;

public class ProgramControllerTests
{
    private readonly ICreateProgramService _createProgramService;
    private readonly IGetProgramService _getProgramService;
    private readonly IUpdateProgramService _updateProgramService;
    private readonly IDeleteProgramService _deleteProgramService;
    private readonly ICreateCandidateService _createCandidateService;

    public ProgramControllerTests()
    {
        _createProgramService = A.Fake<ICreateProgramService>();
        _getProgramService = A.Fake<IGetProgramService>(); ;
        _updateProgramService = A.Fake<IUpdateProgramService>(); ;
        _deleteProgramService = A.Fake<IDeleteProgramService>(); ;
        _createCandidateService = A.Fake<ICreateCandidateService>(); ;
    }


    [Fact]
    public async void ProgramController_GetProgram_ReturnOk()
    {
        //arrange
        var id = "testId";
        var programVm = A.Fake<ProgramVm>();
        A.CallTo(() => _getProgramService.GetProgram(id)).Returns(programVm);
        var controller = new ProgramController(_createProgramService, _getProgramService,  _updateProgramService, _deleteProgramService, _createCandidateService);
        //act

        var result = await controller.GetProgram(id);
        //assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();

    }

    [Fact]
    public async void ProgramController_CreateProgram_ReturnOk()
    {
        //arrange
        var programVm = A.Fake<ProgramVm>();
        var createProgramRequest = A.Fake<CreateProgramRequest>();
        A.CallTo(() => _createProgramService.CreateProgram(createProgramRequest)).Returns(programVm);
        var controller = new ProgramController(_createProgramService, _getProgramService, _updateProgramService, _deleteProgramService, _createCandidateService);

        //act
        var result = await controller.CreateProgram(createProgramRequest);

        //assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async void ProgramController_UpdateProgram_ReturnOk()
    {
        //arrange
        var programVm = A.Fake<ProgramVm>();
        var updateProgramRequest = A.Fake<UpdateProgramRequest>();
        A.CallTo(() => _updateProgramService.UpdateProgram(updateProgramRequest)).Returns(programVm);
        var controller = new ProgramController(_createProgramService, _getProgramService, _updateProgramService, _deleteProgramService, _createCandidateService);

        //act
        var result = await controller.UpdateProgram(updateProgramRequest);

        //assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async void ProgramController_DeleteProgram_ReturnOk()
    {
        //arrange
        var id = "testId";

        A.CallTo(() => _deleteProgramService.DeleteProgram(id)).Returns(true);
        var controller = new ProgramController(_createProgramService, _getProgramService, _updateProgramService, _deleteProgramService, _createCandidateService);

        //act
        var result = await controller.DeleteProgram(id);

        //assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async void ProgramController_CreateCandidate_ReturnOk()
    {
        //arrange
        var candidate = A.Fake<Candidate>();
        var createCandidateRequest = A.Fake<CreateCandidateRequest>();

        A.CallTo(() => _createCandidateService.CreateCandidate(createCandidateRequest)).Returns(candidate);
        var controller = new ProgramController(_createProgramService, _getProgramService, _updateProgramService, _deleteProgramService, _createCandidateService);

        //act
        var result = await controller.CreateCandidate(createCandidateRequest);

        //assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
    }
}
