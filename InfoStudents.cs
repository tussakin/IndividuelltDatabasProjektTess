using IndividuelltDatabasProjektTess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividuelltDatabasProjektTess
{
    internal class InfoStudents
    {
        public static void GetInfoStudents()
        {
            using (var DbContext = new SchoolLabb2Context())
            {
                var allStudents = DbContext.Students.ToList();

                foreach (var student in allStudents)
                {
                    Console.WriteLine($"First name: {student.FirstName}, Last name: {student.LastName}, Student ID: {student.StudentId}");
                    Console.WriteLine("----- \n");
                }
            }
            Console.WriteLine("Press any key to continue to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
