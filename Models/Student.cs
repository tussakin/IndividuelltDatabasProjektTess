using System;
using System.Collections.Generic;

namespace IndividuelltDatabasProjektTess.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public long? SocialSecurityNumber { get; set; }

    public string? Class { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<GradeDetail> GradeDetails { get; set; } = new List<GradeDetail>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
