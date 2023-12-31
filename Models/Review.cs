﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSPO.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? EventId { get; set; }

    public int? SessionId { get; set; }

    public string ReviewerName { get; set; } = null!;

    public int Rating { get; set; }

    public string? ReviewText { get; set; }

    public DateTime? ReviewDate { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Session? Session { get; set; }

    [NotMapped]
    public SelectList list { get; set; }
}
