using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DS_Lab_3.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "EmployeeOnly")]
[AllowAnonymous]
public class EmployeeRoleController:ControllerBase
{
    private readonly IEmployeeRoleService _roleService;

    public EmployeeRoleController(IEmployeeRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var roles = _roleService.GetAllEmployeeRoles();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var role = _roleService.GetEmployeeRoleById(id);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }

    [HttpPost]
    public IActionResult Post([FromBody] EmployeeRole role)
    {
        var createdRole = _roleService.CreateEmployeeRole(role);
        return CreatedAtAction("Get", new { id = createdRole.Id }, createdRole);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] EmployeeRole updatedRole)
    {
        var role = _roleService.UpdateEmployeeRole(id, updatedRole);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _roleService.DeleteEmployeeRole(id);
        return NoContent();
    }
}