using IndividuelltDatabasProjektTess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividuelltDatabasProjektTess
{
    internal class SalaryInfo
    {
        public static void SalaryAverage()
        {
            using (var DbContext = new SchoolLabb2Context())
            {
                var averageSalary = DbContext.Staff.GroupBy(s => s.ProfessionId)
                    .Select(p => new
                    {
                        ProfessionId = p.Key,
                        averageSalaryProfessions = p.Average(s => s.Salary)
                    })
                    .ToList();

                foreach(var result in averageSalary)
                {
                    var professions = DbContext.Professions.Find(result.ProfessionId);
                    var wholeNumberSalary = Convert.ToInt32(result.averageSalaryProfessions);
                    Console.WriteLine($"Staff role: {professions.StaffRole}, Average salary: {wholeNumberSalary}kr");
                }
            }
            Console.WriteLine("Press any key to continue to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }


        public static void SumSalary()
        {
            using (var DbContext = new SchoolLabb2Context())
            {
                var allSumSalary = DbContext.Staff.GroupBy(s => s.ProfessionId)
                    .Select(p => new
                    {
                        ProfessionId = p.Key,
                        SumSalary = p.Sum(s => s.Salary)
                    })
                    .ToList();

                foreach (var result in allSumSalary)
                {
                    var professions = DbContext.Professions.Find(result.ProfessionId);
                    Console.WriteLine($"Staff role: {professions.StaffRole}, Sum of salaries: {result.SumSalary}kr");
                }
            }
            Console.WriteLine("Press any key to continue to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
