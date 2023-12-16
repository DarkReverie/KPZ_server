using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DS_Lab_3.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "MembershipAndEmployee")]
[AllowAnonymous]
public class InvoiceController:ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var invoices = _invoiceService.GetAllInvoices();
        return Ok(invoices);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var invoice = _invoiceService.GetInvoiceById(id);
        if (invoice == null)
        {
            return NotFound();
        }
        return Ok(invoice);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Invoice invoice)
    {
        var createdInvoice = _invoiceService.CreateInvoice(invoice);
        return CreatedAtAction("Get", new { id = createdInvoice.Id }, createdInvoice);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Invoice updatedInvoice)
    {
        var invoice = _invoiceService.UpdateInvoice(id, updatedInvoice);
        if (invoice == null)
        {
            return NotFound();
        }
        return Ok(invoice);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _invoiceService.DeleteInvoice(id);
        return NoContent();
    } 
}