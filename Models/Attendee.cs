using System;
using System.Collections.Generic;

namespace TechSPO.Models;

public partial class Attendee
{
    public int AttendeeId { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactInfo { get; set; }

    public string? GroupDetails { get; set; }

    public int? EventId { get; set; }

    public virtual Event? Event { get; set; }
}
