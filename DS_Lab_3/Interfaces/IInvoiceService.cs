using DS_Lab_3.Models;

namespace DS_Lab_3.Interfaces;

public interface IInvoiceService
{
    Invoice CreateInvoice(Invoice invoice);

    // Get an invoice by its ID
    Invoice GetInvoiceById(int invoiceId);

    // Update an existing invoice
    Invoice UpdateInvoice(int invoiceId, Invoice updatedInvoice);

    // Delete an invoice by its ID
    void DeleteInvoice(int invoiceId);

    // Get a list of all invoices
    IEnumerable<Invoice> GetAllInvoices();
}