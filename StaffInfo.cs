using IndividuelltDatabasProjektTess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IndividuelltDatabasProjektTess
{
    internal class StaffInfo
    {
        public static void GetStaffInfo()
        {
            using (var DbContext = new SchoolLabb2Context())
            {

                var getInfoStaff = DbContext.Staff
                    .Join(
                        DbContext.Professions,
                        staff => staff.ProfessionId,
                        profession => profession.ProfessionId,
                        (staff, profession) => new
                        {
                            StaffID = staff.StaffId,
                            SocialSecurityNumber = staff.SocialSecurityNumber,
                            FirstName = staff.FirstName,
                            LastName = staff.LastName,
                            Salary = staff.Salary,
                            HireDate = staff.HireDate,
                            StaffRole = profession.StaffRole
                        })
                            .ToList();
                foreach (var staffMember in getInfoStaff)
                {
                    Console.WriteLine($"Name: {staffMember.FirstName} {staffMember.LastName}, Role: {staffMember.StaffRole}\nStaff ID: {staffMember.StaffID}, Social security number: {staffMember.SocialSecurityNumber}" +
                        $"\nDate hired: {staffMember.HireDate}, Salary: {staffMember.Salary}kr\n");
                    Console.WriteLine("-----");
                }
                Console.WriteLine("Press any key to continue to the main menu...");
                Console.ReadKey();
                Console.Clear();

            }

        }

        public static void StaffInDepartments()
        {
            using (var DbContext = new SchoolLabb2Context())
            {
                var staffCountByDepartment = DbContext.Staff
                    .GroupBy(s => s.ProfessionId)
                    .Select(g => new
                    {
                        ProfessionId = g.Key,
                        StaffCount = g.Count()
                    })
                    .ToList();

                foreach (var departmentInfo in staffCountByDepartment)
                {
                    var profession = DbContext.Professions
                        .FirstOrDefault(p => p.ProfessionId == departmentInfo.ProfessionId);
                    Console.WriteLine($"The school has {departmentInfo.StaffCount} {profession?.StaffRole ?? "Unknown Role"}s");
                    Console.WriteLine("----- \n");
                }
            }
            Console.WriteLine("Press any key to continue to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
