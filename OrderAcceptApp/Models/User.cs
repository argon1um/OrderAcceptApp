using System;
using System.Collections.Generic;

namespace OrderAcceptApp.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserSurname { get; set; }

    public string? UserPatronymic { get; set; }

    public string? UserLogin { get; set; }

    public string? UserPassword { get; set; }

    public int? UserSubdivisionid { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual Subdivision? UserSubdivision { get; set; }
}
