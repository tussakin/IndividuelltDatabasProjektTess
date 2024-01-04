using System;
using System.Collections.Generic;

namespace IndividuelltDatabasProjektTess.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int? FkStudentId { get; set; }

    public int? FkCourseId { get; set; }

    public int? FkGradeId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime StopDate { get; set; }

    public DateTime GradeDate { get; set; }

    public int TeacherId { get; set; }

    public virtual Course? FkCourse { get; set; }

    public virtual Grade? FkGrade { get; set; }

    public virtual Student? FkStudent { get; set; }
}
