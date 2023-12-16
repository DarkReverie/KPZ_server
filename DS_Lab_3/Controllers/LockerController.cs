using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DS_Lab_3.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "MembershipAndEmployee")]
[AllowAnonymous]
public class LockerController:ControllerBase
{
    private readonly ILockerService _lockerService;

    public LockerController(ILockerService lockerService)
    {
        _lockerService = lockerService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var lockers = _lockerService.GetAllLockers();
        return Ok(lockers);
    }

    [HttpGet("{id}", Name = "GetLocker")]
    public IActionResult Get(int id)
    {
        var locker = _lockerService.GetLockerById(id);
        if (locker == null)
        {
            return NotFound();
        }
        return Ok(locker);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Locker locker)
    {
        var createdLocker = _lockerService.CreateLocker(locker);
        return CreatedAtAction("Get", new { id = createdLocker.Id }, createdLocker);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Locker updatedLocker)
    {
        var locker = _lockerService.UpdateLocker(id, updatedLocker);
        if (locker == null)
        {
            return NotFound();
        }
        return Ok(locker);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _lockerService.DeleteLocker(id);
        return NoContent();
    }
}