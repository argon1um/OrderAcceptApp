using System;
using System.Collections.Generic;

namespace OrderAcceptApp.Models;

public partial class Request
{
    public int RequsetId { get; set; }

    public int? UserId { get; set; }

    public int? ServiceId { get; set; }

    public DateOnly? RequestDate { get; set; }

    public string? RequestTheme { get; set; }

    public string? RequestDecsription { get; set; }

    public string? Response { get; set; }

    public virtual Service? Service { get; set; }

    public virtual User? User { get; set; }
}
