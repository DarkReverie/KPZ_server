using System;
using System.Collections.Generic;

namespace DS_Lab_3.Models;

public partial class Shopitem
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? StockQuantity { get; set; }
}
