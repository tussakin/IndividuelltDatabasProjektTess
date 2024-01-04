using IndividuelltDatabasProjektTess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividuelltDatabasProjektTess
{
    internal class ChooseStudent
    {
        public void GetStudentInfoByIdFromUserInput()
        {
            Console.Write("Enter StudentID: ");
            if (int.TryParse(Console.ReadLine(), out int userInputId))
            {
                GetStudentInfoById(userInputId);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for StudentID.");
            }
        }

        public void GetStudentInfoById(int studentId)
        {
            using (var dbContext = new SchoolLabb2Context())
            {
                var studentInfo = dbContext.StudentInfo
                    .FromSqlRaw("EXEC GetStudentInfoById @StudentId", new SqlParameter("StudentId", studentId))
                    .AsEnumerable()
                    .FirstOrDefault();

                if (studentInfo != null)
                {
                    Console.WriteLine($"Name: {studentInfo.FirstName} {studentInfo.LastName}\nSocial security number {studentInfo.SocialSecurityNumber}");
                    Console.WriteLine("-----");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
                Console.WriteLine("Press any key to continue to the main menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}

