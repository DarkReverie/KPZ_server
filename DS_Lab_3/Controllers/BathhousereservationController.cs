using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DS_Lab_3.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "MembershipAndEmployee")]
[AllowAnonymous]
public class BathhousereservationController:ControllerBase
{
    private readonly IBathhousereservationService _reservationService;

    public BathhousereservationController(IBathhousereservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var reservations = _reservationService.GetAllReservations();
        return Ok(reservations);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var reservation = _reservationService.GetReservationById(id);
        if (reservation == null)
        {
            return NotFound();
        }
        return Ok(reservation);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Bathhousereservation reservation)
    {
        var createdReservation = _reservationService.CreateReservation(reservation);
        return CreatedAtAction("Get", new { id = createdReservation.Id }, createdReservation);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Bathhousereservation updatedReservation)
    {
        var reservation = _reservationService.UpdateReservation(id, updatedReservation);
        if (reservation == null)
        {
            return NotFound();
        }
        return Ok(reservation);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _reservationService.DeleteReservation(id);
        return NoContent();
    }
}