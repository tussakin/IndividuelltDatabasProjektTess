using System;
using System.Collections.Generic;

namespace IndividuelltDatabasProjektTess.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public char? Grade1 { get; set; }

    public int? FkStudentId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Student? FkStudent { get; set; }

    public virtual ICollection<GradeDetail> GradeDetails { get; set; } = new List<GradeDetail>();
}
