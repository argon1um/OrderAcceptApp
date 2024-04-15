using System;
using System.Collections.Generic;

namespace OrderAcceptApp.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
