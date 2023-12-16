

namespace DS_Lab_3.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? InvoiceDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public string? Comment { get; set; }

    public int? MemberId { get; set; }
}
