using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DS_Lab_3.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "MembershipAndEmployee")]
[AllowAnonymous]
public class TrainerSessionController:ControllerBase
{
    private readonly ITrainersessionService _trainersessionService;

    public TrainerSessionController(ITrainersessionService  trainersessionService)
    {
        _trainersessionService =  trainersessionService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var trainerSessions = _trainersessionService.GetAllTrainerSessions();
        return Ok(trainerSessions);
    }

    [HttpGet("{id}", Name = "GetTrainerSession")]
    public IActionResult Get(int id)
    {
        var trainerSession = _trainersessionService.GetTrainerSessionById(id);
        if (trainerSession == null)
        {
            return NotFound();
        }
        return Ok(trainerSession);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Trainersession trainerSession)
    {
        var createdTrainerSession = _trainersessionService.CreateTrainerSession(trainerSession);
        return CreatedAtAction("Get", new { id = createdTrainerSession.Id }, createdTrainerSession);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]  Trainersession updatedTrainerSession)
    {
        var trainerSession = _trainersessionService.UpdateTrainerSession(id, updatedTrainerSession);
        if (trainerSession == null)
        {
            return NotFound();
        }
        return Ok(trainerSession);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _trainersessionService.DeleteTrainerSession(id);
        return NoContent();
    }
}

