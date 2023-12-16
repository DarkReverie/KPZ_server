using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DS_Lab_3.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "MembershipOnly")]
[AllowAnonymous]
public class MembershipController:ControllerBase
{
    private readonly IMembershipService _membershipService;

    public MembershipController(IMembershipService membershipService)
    {
        _membershipService = membershipService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var memberships = _membershipService.GetAllMemberships();
        return Ok(memberships);
    }

    [HttpGet("{id}", Name = "GetMembership")]
    public IActionResult Get(int id)
    {
        var membership = _membershipService.GetMembershipById(id);
        if (membership == null)
        {
            return NotFound();
        }
        return Ok(membership);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Membership membership)
    {
        var createdMembership = _membershipService.CreateMembership(membership);
        return CreatedAtAction("Get", new { id = createdMembership.Id }, createdMembership);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Membership updatedMembership)
    {
        var membership = _membershipService.UpdateMembership(id, updatedMembership);
        if (membership == null)
        {
            return NotFound();
        }
        return Ok(membership);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _membershipService.DeleteMembership(id);
        return NoContent();
    }
}