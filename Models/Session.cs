﻿using System;
using System.Collections.Generic;

namespace TechSPO.Models;

public partial class Session
{
    public int SessionId { get; set; }

    public string SessionName { get; set; } = null!;

    public DateTime? Time { get; set; }

    public string? Speaker { get; set; }

    public string? Description { get; set; }

    public int? EventId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
