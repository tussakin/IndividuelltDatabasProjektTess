using IndividuelltDatabasProjektTess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IndividuelltDatabasProjektTess
{
    internal class SetGrade
    {
        public static void GradeSetting()
        {

            while (true)
            {
                try
                {
                    using (var dbContext = new SchoolLabb2Context())
                    {
                        using (var transaction = dbContext.Database.BeginTransaction())
                        {
                            try
                            {
                                DateTime gradeDate = DateTime.Now;
                                Console.Write("Enter Student ID: ");
                                if (int.TryParse(Console.ReadLine(), out int studentId))
                                {
                                    Console.Write("Enter Course ID: ");
                                    if (int.TryParse(Console.ReadLine(), out int courseId))
                                    {
                                        Console.Write("Enter Grade (A, B, C, D, E or F): ");
                                        string gradeInput = Console.ReadLine()?.ToUpper();

                                        char gradeId;
                                        switch (gradeInput)
                                        {
                                            case "A":
                                                gradeId = 'A';
                                                break;
                                            case "B":
                                                gradeId = 'B';
                                                break;
                                            case "C":
                                                gradeId = 'C';
                                                break;
                                            case "D":
                                                gradeId = 'D';
                                                break;
                                            case "E":
                                                gradeId = 'E';
                                                break;
                                            case "F":
                                                gradeId = 'F';
                                                break;

                                            default:
                                                Console.WriteLine("Invalid input for Grade.");
                                                return;
                                        }

                                        var isStudentValid = dbContext.Students.Any(s => s.StudentId == studentId);
                                        var isCourseValid = dbContext.Courses.Any(c => c.CourseId == courseId);
                                        var isGradeValid = dbContext.Grades.Any(g => g.Grade1 == gradeId);
                                        var date = dbContext.Enrollments.Any(gd => gd.GradeDate == gradeDate);

                                        if (isStudentValid && isCourseValid && isGradeValid)
                                        {
                                            try
                                            {
                                                var enrollment = new Enrollment
                                                {
                                                    FkStudentId = studentId,
                                                    FkCourseId = courseId,
                                                    GradeDate = gradeDate,
                                                    FkGradeId = dbContext.Grades.First(g => g.Grade1 == gradeId).GradeId
                                                };

                                                dbContext.Enrollments.Add(enrollment);
                                                dbContext.SaveChanges();

                                                transaction.Commit();
                                                Console.WriteLine("Grade added.");
                                                break;
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("Failed to add grade using EF. Attempting stored procedure...");

                                                if (TryAddGradeWithStoredProcedure(studentId, courseId, gradeId, gradeDate, dbContext))
                                                {
                                                    Console.WriteLine("Grade added using stored procedure.");
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Failed to add grade using stored procedure as well.");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please make sure every input matches existing records.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a valid number for the Course ID.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid number for the Student ID.");
                                }
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                Console.WriteLine($"Error enrolling student. Transaction rolled back. {ex.ToString()}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error connecting to the database. {ex.Message}");
                }
            }

            Console.WriteLine("Press any key to continue to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }

        private static bool TryAddGradeWithStoredProcedure(int studentId, int courseId, char gradeId, DateTime gradeDate, SchoolLabb2Context dbContext)
        {
            try
            {
                var studentIdParam = new SqlParameter("@StudentID", studentId);
                var courseIdParam = new SqlParameter("@CourseID", courseId);
                var gradeParam = new SqlParameter("@Grade", gradeId.ToString());
                var setDateParam = new SqlParameter("@SetDate", gradeDate);

                dbContext.Database.ExecuteSqlRaw("EXEC AddGrade @StudentID, @CourseID, @Grade, @SetDate", studentIdParam, courseIdParam, gradeParam, setDateParam);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to add grade using stored procedure. {ex.ToString()}");
                return false;
            }
        }
    }
}


