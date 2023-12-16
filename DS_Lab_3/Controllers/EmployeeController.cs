using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DS_Lab_3.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "EmployeeOnly")]

public class EmployeeController:ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var employees = _employeeService.GetAllEmployees();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var employee = _employeeService.GetEmployeeById(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Employee employee)
    {
        var createdEmployee = _employeeService.CreateEmployee(employee);
        return CreatedAtAction("Get", new { id = createdEmployee.Id }, createdEmployee);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Employee updatedEmployee)
    {
        var employee = _employeeService.UpdateEmployee(id, updatedEmployee);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _employeeService.DeleteEmployee(id);
        return NoContent();
    }  
}