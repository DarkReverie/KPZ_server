using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DS_Lab_3.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "MembershipOnly")]
[AllowAnonymous]
public class PaymentController:ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var payments = _paymentService.GetAllPayments();
        return Ok(payments);
    }

    [HttpGet("{id}", Name = "GetPayment")]
    public IActionResult Get(int id)
    {
        var payment = _paymentService.GetPaymentById(id);
        if (payment == null)
        {
            return NotFound();
        }
        return Ok(payment);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Payment payment)
    {
        var createdPayment = _paymentService.CreatePayment(payment);
        return CreatedAtAction("Get", new { id = createdPayment.Id }, createdPayment);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Payment updatedPayment)
    {
        var payment = _paymentService.UpdatePayment(id, updatedPayment);
        if (payment == null)
        {
            return NotFound();
        }
        return Ok(payment);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _paymentService.DeletePayment(id);
        return NoContent();
    }
}