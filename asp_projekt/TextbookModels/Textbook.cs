using System;
using System.Collections.Generic;

namespace asp_projekt.TextbookModels;

public partial class Textbook
{
    public int TextbookId { get; set; }

    public string? StockNumber { get; set; }

    public string? Title { get; set; }

    public double? Price { get; set; }

    public bool NotAvailable { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
