using IndividuelltDatabasProjektTess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividuelltDatabasProjektTess
{
    internal class InfoCourses
    {
        public static void GetInfoCourses()
        {
            using (var DbContext = new SchoolLabb2Context())
            {
                var activeCourses = DbContext.Enrollments
            .Where(enrollment => enrollment.StartDate <= DateTime.Now && enrollment.StopDate >= DateTime.Now)
            .Join(
                DbContext.Courses,
                enrollment => enrollment.FkCourseId,
                course => course.CourseId,
                (enrollment, course) => new
                {
                    CourseName = course.CourseName,
                    CourseDescription = course.CourseDescription
                }
            )
            .ToList();


                foreach (var Course in activeCourses)
                {
                    Console.WriteLine($"{Course.CourseName}, {Course.CourseDescription}");
                    Console.WriteLine("----- \n");
                }
            }
            Console.WriteLine("Press any key to continue to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
