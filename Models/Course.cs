using System;
using System.Collections.Generic;

namespace IndividuelltDatabasProjektTess.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public string? CourseDescription { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<GradeDetail> GradeDetails { get; set; } = new List<GradeDetail>();
}
