using IndividuelltDatabasProjektTess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividuelltDatabasProjektTess
{
    internal class AddStudent
    {
        public static void AddNewStudent()
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

                        Console.WriteLine("Please enter class: ");
                        string? className = Console.ReadLine();

                        var newStudent = new Student
                        {
                            SocialSecurityNumber = socialSecurityNumber,
                            FirstName = firstName,
                            LastName = lastName,
                            Class = className
                        };

                        DbContext.Students.Add(newStudent);
                        DbContext.SaveChanges();

                        Console.WriteLine("Student added!");


                    }
                    else
                    {
                        Console.WriteLine("Please add a valid social security number.");
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
    

