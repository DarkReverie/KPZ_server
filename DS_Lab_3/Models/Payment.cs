using System;
using System.Collections.Generic;

namespace DS_Lab_3.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int? InvoiceId { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public decimal? PaymentAmount { get; set; }

    public int? MemberId { get; set; }
}
