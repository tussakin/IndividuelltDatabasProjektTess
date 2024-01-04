using IndividuelltDatabasProjektTess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividuelltDatabasProjektTess
{
    internal class Menu
    {
        public static void MainMenu()
        {
            while(true)
            {
                Console.WriteLine("1.Staff information\n2.Add new staff\n3.Get info courses\n4.Get info on all students\n5.Average salary per department\n" +
                    "6.Sum of all saralys per department\n7.Staff per department\n8.Info on student\n9. Set grade\n10.Add new student");

                var MenuInput = Console.ReadLine();

                if(int.TryParse(MenuInput, out int number))
                {
                    switch (number)
                    {
                        case 1:
                            StaffInfo.GetStaffInfo();
                            break;
                        case 2:
                            AddStaff.AddNewStaff();
                            break;
                        case 3:
                            InfoCourses.GetInfoCourses();
                            break;
                        case 4:
                            InfoStudents.GetInfoStudents();
                            break;
                        case 5:
                            SalaryInfo.SalaryAverage();
                            break;
                        case 6:
                            SalaryInfo.SumSalary();
                            break;
                        case 7:
                            StaffInfo.StaffInDepartments();
                            break;
                        case 8:
                            ChooseStudent chooseStudentInstance = new ChooseStudent();
                            chooseStudentInstance.GetStudentInfoByIdFromUserInput();
                            break;
                        case 9:
                            SetGrade.GradeSetting();
                            break;
                        case 10:
                            AddStudent.AddNewStudent();
                            break;


                    }
                }
                else
                {
                    Console.WriteLine("You need to choose and enter a number from the list");
                }
            }
        }
    }
}
