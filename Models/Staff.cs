using System;
using System.Collections.Generic;

namespace IndividuelltDatabasProjektTess.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public int? ProfessionId { get; set; }

    public long? SocialSecurityNumber { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public long? Salary { get; set; }

    public DateTime? HireDate { get; set; }
}
