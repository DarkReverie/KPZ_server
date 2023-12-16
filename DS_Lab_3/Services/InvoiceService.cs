using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;

namespace DS_Lab_3.Services;

public class InvoiceService:IInvoiceService
{
    private readonly GymDsCopyContext _context;

    public InvoiceService(GymDsCopyContext context)
    {
        _context = context;
    }

    public Invoice CreateInvoice(Invoice invoice)
    {
        _context.Invoices.Add(invoice);
        _context.SaveChanges();
        return invoice;
    }

    public Invoice GetInvoiceById(int invoiceId)
    {
        return _context.Invoices.Find(invoiceId);
    }

    public Invoice UpdateInvoice(int invoiceId, Invoice updatedInvoice)
    {
        var existingInvoice = _context.Invoices.Find(invoiceId);

        if (existingInvoice != null)
        {
            existingInvoice.Amount = updatedInvoice.Amount;
            existingInvoice.Comment = updatedInvoice.Comment;
            existingInvoice.DueDate = updatedInvoice.DueDate;
            existingInvoice.InvoiceDate = updatedInvoice.InvoiceDate;
            existingInvoice.MemberId = updatedInvoice.MemberId;
            // Update other properties as needed

            _context.SaveChanges();
        }

        return existingInvoice;
    }

    public void DeleteInvoice(int invoiceId)
    {
        var invoiceToDelete = _context.Invoices.Find(invoiceId);

        if (invoiceToDelete != null)
        {
            _context.Invoices.Remove(invoiceToDelete);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Invoice> GetAllInvoices()
    {
        return _context.Invoices;
    }
}