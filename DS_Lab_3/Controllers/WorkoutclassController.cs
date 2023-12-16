using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DS_Lab_3.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "MembershipAndEmployee")]
[AllowAnonymous]
public class WorkoutclassController:ControllerBase
{
    private readonly IWorkoutclassService _workoutclassService;

    public WorkoutclassController(IWorkoutclassService  workoutclassService)
    {
        _workoutclassService =  workoutclassService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var workoutclasses = _workoutclassService.GetAllWorkoutClasses();
        return Ok(workoutclasses);
    }

    [HttpGet("{id}", Name = "GetWorkoutClass")]
    public IActionResult Get(int id)
    {
        var workoutClass = _workoutclassService.GetWorkoutClassById(id);
        if (workoutClass == null)
        {
            return NotFound();
        }
        return Ok(workoutClass);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Workoutclass workoutClass)
    {
        var createdWorkoutClass = _workoutclassService.CreateWorkoutClass(workoutClass);
        return CreatedAtAction("Get", new { id = createdWorkoutClass.Id }, createdWorkoutClass);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]  Workoutclass updatedWorkoutClass)
    {
        var workoutClass = _workoutclassService.UpdateWorkoutClass(id, updatedWorkoutClass);
        if (workoutClass == null)
        {
            return NotFound();
        }
        return Ok(workoutClass);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _workoutclassService.DeleteWorkoutClass(id);
        return NoContent();
    }
}