using System;
using System.Collections.Generic;
using System.Linq;

namespace primaryConsoleApp
{
    class Employee
    {

        public string Name { get; set; }

        public string Designation { get; set; }

        public int Age { get; set; }

        public decimal Salary { get; set; }

        public int Id{get; set;}
       
    }
    class data
    {
        public static void Main(String[] args)
        {
            List<Employee> emp = new List<Employee>();
            int proceed = 1;
            while (proceed !=0)
            {
                Console.WriteLine("\n\n* * MENU DRIVEN * *\n\n1.Insert Information\n2.Delete Information\n3.Display Information\n4.Exit \n");
                Console.Write("Enter Choice:\t");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Employee e1 = new Employee();
                        Console.Write("Enter name of first Employee:");
                        e1.Name = Console.ReadLine();
                        Console.Write("Enter designation of first Employee:");
                        e1.Designation = Console.ReadLine();
                        Console.Write("Enter age of first Employee:");
                        e1.Age = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter salary of first Employee:");
                        e1.Salary = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter employee Id of first Employee:");
                        e1.Id = Convert.ToInt32(Console.ReadLine());
                        emp.Add(e1);

                        Employee e2 = new Employee();
                        Console.Write("Enter name of second Employee:");
                        e2.Name = Console.ReadLine();
                        Console.Write("Enter designation of second Employee:");
                        e2.Designation = Console.ReadLine();
                        Console.Write("Enter age of second Employee:");
                        e2.Age = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter salary of second Employee:");
                        e2.Salary = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter employee Id of second Employee:");
                        e2.Id = Convert.ToInt32(Console.ReadLine());
                        emp.Add(e2);

                        Employee e3 = new Employee();
                        Console.Write("Enter name of third Employee:");
                        e3.Name = Console.ReadLine();
                        Console.Write("Enter designation of third Employee:");
                        e3.Designation = Console.ReadLine();
                        Console.Write("Enter age of third Employee:");
                        e3.Age = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter salary of third Employee:");
                        e3.Salary = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter employee Id of third Employee:");
                        e3.Id = Convert.ToInt32(Console.ReadLine());
                        emp.Add(e3);

                        Employee e4 = new Employee();
                        Console.Write("Enter name of foruth Employee:");
                        e4.Name = Console.ReadLine();
                        Console.Write("Enter designation of foruth Employee:");
                        e4.Designation = Console.ReadLine();
                        Console.Write("Enter age of foruth Employee:");
                        e4.Age = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter salary of foruth Employee:");
                        e4.Salary = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter employee Id of foruth Employee:");
                        e4.Id = Convert.ToInt32(Console.ReadLine());
                        emp.Add(e4);
                        break;
                    case 2:
                        Console.Write("Enter Employee id whose information has to be deleted: ");
                        int i = Convert.ToInt32(Console.ReadLine());
                        foreach (Employee e in emp)
                        {
                            if(e.Id==i)
                            {
                                emp.Remove(e);
                                Console.WriteLine("Information of employee with employee id {0} deleted successfully!!!!",i);
                                break;
                                
                            }
                        };
                        break;
                    case 3:
                        foreach (Employee e in emp)
                        {
                            Console.WriteLine($"Employee Name\t{e.Name}");
                            Console.WriteLine($"Employee Age\t{e.Age}");
                            Console.WriteLine($"Employee Designation\t{e.Designation}");
                            Console.WriteLine($"Employee Salary\t{e.Salary}");
                            Console.WriteLine($"Employee Id\t{e.Id} ");
                        };
                        break;
                    case 4:
                        proceed = 0;
                        break;
                    default:
                        Console.WriteLine("Invalid choice ");
                        break;
                }
                Console.Write("press 0 to exit else anyother number to continue : ");
                proceed = Convert.ToInt32(Console.ReadLine());
            }
        }
    }    
}
