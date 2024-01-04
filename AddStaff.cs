using IndividuelltDatabasProjektTess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividuelltDatabasProjektTess
{
    internal class AddStaff
    {
            public static void AddNewStaff()
            {
            try
            {
                using (var DbContext = new SchoolLabb2Context())
                {
                    Console.WriteLine("Please enter social security number: ");
                    if (long.TryParse(Console.ReadLine(), out long socialSecurityNumber))
                    {
                        Console.WriteLine("Please enter first name: ");
                        string? firstName = Console.ReadLine();

                        Console.WriteLine("Please enter last name: ");
                        string? lastName = Console.ReadLine();

                        DateTime hireDate = DateTime.Now;

                        Console.WriteLine("Please enter Profession: ");
                        Console.WriteLine("1.Teacher\n2.Principal\n3.Janitor\n4.Teachers aid\n5.Lunch staff\n6.Guidance counselor");
                        if (int.TryParse(Console.ReadLine(), out int professionId))
                        {
                            switch (professionId)
                            {
                                case 1:
                                    professionId = 1;
                                    break;
                                case 2:
                                    professionId = 2;
                                    break;
                                case 3:
                                    professionId = 3;
                                    break;
                                case 4:
                                    professionId = 4;
                                    break;
                                case 5:
                                    professionId = 5;
                                    break;
                                case 6:
                                    professionId = 6;
                                    break;

                                default:
                                    Console.WriteLine("Invalid input for profession.");
                                    return;
                            }
                            Console.WriteLine("Please enter salary: ");
                            if (long.TryParse(Console.ReadLine(), out long salary))
                            {

                            }


                            var newStaff = new Staff
                            {
                                SocialSecurityNumber = socialSecurityNumber,
                                FirstName = firstName,
                                LastName = lastName,
                                ProfessionId = professionId,
                                HireDate = hireDate,
                                Salary = salary
                            };

                            DbContext.Staff.Add(newStaff);
                            DbContext.SaveChanges();

                            Console.WriteLine("Staff added!");


                        }
                        else
                        {
                            Console.WriteLine("Please add a valid social security number.");
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong. {ex.ToString()}");
            }
                Console.WriteLine("Press any key to continue to the main menu...");
                Console.ReadKey();
                Console.Clear();
            }

    }
}
