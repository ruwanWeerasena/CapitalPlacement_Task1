using CapitalPlacement_Task1.Controllers.Requests;
using CapitalPlacement_Task1.Services;
using CapitalPlacement_Task1.Services.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement_Task1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgramController : ControllerBase
{
    private readonly ICreateProgramService _createProgramService;
    private readonly IGetProgramService _getProgramService;
    private readonly IUpdateProgramService _updateProgramService;

    public ProgramController(ICreateProgramService createProgramService, IGetProgramService getProgramService, IUpdateProgramService updateProgramService)
    {
        _createProgramService = createProgramService;
        _getProgramService = getProgramService;
        _updateProgramService = updateProgramService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProgram([FromBody] CreateProgramRequest programRequest)
    {

        var result = await _createProgramService.CreateProgram(programRequest);
        if (result is not null)
        {
            return Ok(result);
        }
        return Problem("Operation Failed");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProgram(string id)
    {

        var result = await _getProgramService.GetProgram(id);
        if (result is not null)
        {
            return Ok(result);
        }
        return Problem("Operation Failed");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProgram([FromBody] UpdateProgramRequest request)
    {

        var result = await _updateProgramService.UpdateProgram(request);
        if (result is not null)
        {
            return Ok(result);
        }
        return Problem("Operation Failed");
    }
}
