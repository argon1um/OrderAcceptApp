using System;
using System.Collections.Generic;

namespace OrderAcceptApp.Models;

public partial class Subdivision
{
    public int SubdivisionId { get; set; }

    public string? SubdivisionName { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
