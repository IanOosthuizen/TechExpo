using System;
using System.Collections.Generic;

namespace TechSPO.Models;

public partial class DiscountCode
{
    public string Code { get; set; } = null!;

    public decimal DiscountPercentage { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public int? EventId { get; set; }

    public virtual Event? Event { get; set; }
}
