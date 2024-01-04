using System;
using System.Collections.Generic;

namespace IndividuelltDatabasProjektTess.Models;

public partial class CourseTeacher
{
    public int? FkCourseId { get; set; }

    public int? FkTeacherId { get; set; }

    public virtual Course? FkCourse { get; set; }

    public virtual Staff? FkTeacher { get; set; }
}
