using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace EmployeeIndexer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)

            {
                Console.Clear();

                Console.WriteLine("Menu");

                Console.WriteLine("====");

                Console.WriteLine("1.Add an Employee Record");

                Console.WriteLine("2.Display Employee Record(s)");

                Console.WriteLine("3.Exit");
                Console.WriteLine("Enter your choice");
                int ch = Int32.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:

                        Employee_List emplist = new Employee_List();

                        emplist.AddEmployee();

                        break;

                    case 2:

                        for (int i = 0; i< 10; i++)

                        {

                            Console.WriteLine();

                        }

                        break;
                }

            }

        }
    }
    class Employee
    {
        string ename, edept;
        int eno, esal;
        public Employee()
        {
            ename="";
            edept="";
            eno=0;
            esal=0;
        }
        public Employee(string name, string dept, int num, int sal)
        {
            ename=name;
            edept=dept;
            eno=num;
            esal=sal;
        }
        public Employee this[int pos]
        {
            get
            {
                if (pos > 0 && pos <= 9)
           
                {
                    return this;
                }

            }
        }
    }
      class Employee_List

        {
            Employee[] emp = new Employee[10];

            int index = 0;
            public void AddEmployee()
            {

                string name, dept;

                int num, sal;
                Console.WriteLine("Enter the details");
                Console.WriteLine("NAME:");
                name=Console.ReadLine();
                Console.WriteLine("DEPARTMENT:");
                dept=Console.ReadLine();
                Console.WriteLine("EMPLOYEE NUMBER:");
                num=Int32.Parse(Console.ReadLine());
                Console.WriteLine("SALARY:");
                sal=Int32.Parse(Console.ReadLine());
                emp[index]=new Employee(name, dept, num, sal);
                index++;
            }
        }
    }