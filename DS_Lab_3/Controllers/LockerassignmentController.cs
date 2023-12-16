    using DS_Lab_3.Interfaces;
    using DS_Lab_3.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    namespace DS_Lab_3.Controllers;
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "MembershipAndEmployee")]
    [AllowAnonymous]
    public class LockerassignmentController:ControllerBase
    {
        private readonly ILockerassignmentService _lockerassignmentService;

        public LockerassignmentController(ILockerassignmentService lockerassignmentService)
        {
            _lockerassignmentService = lockerassignmentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var assignments = _lockerassignmentService.GetAllLockerAssignments();
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var assignment = _lockerassignmentService.GetLockerAssignmentById(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Lockerassignment assignment)
        {
            var createdAssignment = _lockerassignmentService.CreateLockerAssignment(assignment);
            return CreatedAtAction("Get", new { id = createdAssignment.Id }, createdAssignment);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Lockerassignment updatedAssignment)
        {
            var assignment = _lockerassignmentService.UpdateLockerAssignment(id, updatedAssignment);
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _lockerassignmentService.DeleteLockerAssignment(id);
            return NoContent();
        }
    }