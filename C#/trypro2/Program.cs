using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace EmployeeInformationDetail
{

    public enum TGCEmployeeType { Secretary, Sales, Manager, TopManager }; //Declaring ENUM that is used to define the type of employee

    public struct TGCEmployeeSalaryInfo //defining struct that will contain the salary information for each employee
    {
        public float hourlyWage;
        public int monthlyHours;
        public float baseSalary;
        public int numSales;
        public float salaryBonus;

        public TGCEmployeeSalaryInfo(TGCEmployeeType emType)    //constructor for salary info sruct
        {
            this.hourlyWage = 0;
            this.monthlyHours = 0;
            this.baseSalary = 0;
            this.numSales = 0;
            this.salaryBonus = 0;
            if (emType == (TGCEmployeeType)2)  //if employee type is a manager than his bonus will be 1500
                this.salaryBonus = 1500;
            if (emType == (TGCEmployeeType)3)   //if employee type is a top manager than his bonus will be 5000
                this.salaryBonus = 5000;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the TGC Employee System");
            TGCEmployeeArray empArray = new TGCEmployeeArray();  //Creating an empty list of employees.

            int continueRunning = 1;
            do                                                    //a do-while loop to run the main menu for the user including the following actions: 
            {
                Console.WriteLine();
                Console.WriteLine("Please Enter Your Choice:");
                Console.WriteLine("1. Enter new employee");        //1-Enter a new employee
                Console.WriteLine("2. Update existing employee");    //2-Update an existing employee
                Console.WriteLine("3. Delete employee");          //3-Deleting an employee
                Console.WriteLine("4. Print employee list");      //4-Printing the employee list
                Console.WriteLine("Any Other Number to Exit");                int userChoice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (userChoice)
                {
                    case 1:                                      //If user wishes to enter new employee
                        TGCEmployee emp = CreateNewWorker();        //Asking for employee information by creating a new employee.
                        if (!(empArray.Contains(emp)))            //Checking to see that employee does not exist
                            empArray.Add(emp);                    //If the employee does not exist in the list then we can add it.
                        else
                            Console.WriteLine("Can not add new worker. This worker already exists");
                        break;
                    case 2:                                      //If user wishes to edit an employee
                        EditEmployee(empArray);
                        break;
                    case 3:
                        DeleteEmployee(empArray);                  //if user wishes to delete an employee from the list
                        break;
                    case 4:
                        empArray.Print();
                        break;
                    default:
                        continueRunning = 0;                        //If user has chosen to exit the system.
                        break;
                }
            } while (continueRunning == 1);                      //Checking to see if to continue running the system
        }
        static TGCEmployee CreateNewWorker()                                                    //Method for creating a new employee.
        {
            TGCEmployee emp;                                                                    //A new employee consists of the basic information which is
            Console.WriteLine("Enter first name:");                                          //The first name
            string first = Console.ReadLine();
            Console.WriteLine("Enter last name:");                                            //The family name
            string last = Console.ReadLine();
            Console.WriteLine("Enter birth date in DD/MM/YYYY format");                      //and birthday.
            DateTime bDay = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Is worker 1=Secretary, 2=Sales, 3=Manager, 4=Top Manager?");  //Also asking for the type
            TGCEmployeeType workerType = (TGCEmployeeType)int.Parse(Console.ReadLine()) - 1;
            TGCEmployeeSalaryInfo salInfo = GetSalaryInfo(workerType);                        //and the salary information
            emp = new TGCEmployee(first, last, bDay, workerType, salInfo);                    //with all the info can create a new employee
            return emp;
        }
        static void EditEmployee(TGCEmployeeArray employees)                                    //Method for editing an employee and his info   
        {

            TGCEmployee emp = GetEmployeeInfo();                                                //First getting basic info about employee to edit.
            TGCEmployeeSalaryInfo salInfo = new TGCEmployeeSalaryInfo();
            if (employees.Contains(emp))                                                        //Then checking that list has this employee (if not can not edit)
            {
                Console.WriteLine("Has worker position changed? 1=Yes, 2=No");
                int changeType = int.Parse(Console.ReadLine());
                if (changeType == 1)                                                            //If employee type has changed
                {                                                                              //then ask for new type
                    Console.WriteLine("Is worker 1=Secretary, 2=Sales, 3=Manager, 4=Top Manager?");
                    TGCEmployeeType workerType = (TGCEmployeeType)int.Parse(Console.ReadLine()) - 1;
                    salInfo = GetSalaryInfo(workerType);                                         //and then ask for his salary info
                    employees.Replace(emp, workerType, salInfo);                                 //and finally replace the info in the salary list.
                }
                else                                                                             //if type ha not changed   
                {
                    salInfo = GetSalaryInfo(employees.Find(emp));                               //then get only the salary info (without the need for the type)
                    employees.Replace(emp, employees.Find(emp), salInfo);                       //and finally replace the info in the salary list.  
                }
            }
            else
                Console.WriteLine("There is no such employee");

        }

        static void DeleteEmployee(TGCEmployeeArray employees)                                //Method for deleting an employee from the list
        {
            TGCEmployee emp = GetEmployeeInfo();                                                //First getting the info of the employee to delete
            if (employees.Contains(emp))                                                        //Then checking if he exists in the list
            {
                Console.WriteLine("Deleting employee");
                employees.Remove(emp);                                                        //If he exists then delete him
            }
            else
                Console.WriteLine("There is no such employee");                              //If he does not exist then tell the user
        }

        static TGCEmployee GetEmployeeInfo()                    //A method for getting the basic information about an employee which includes
        {
            Console.WriteLine("Enter first name of the employee");
            string first = Console.ReadLine();                //His First name
            Console.WriteLine("Enter last name of the employee");
            string last = Console.ReadLine();                  //His last name
            Console.WriteLine("Enter birth date in DD/MM/YYYY format");
            DateTime bDay = DateTime.Parse(Console.ReadLine()); //And his birthday
            TGCEmployee emp = new TGCEmployee(first, last, bDay);
            return emp;                                      //and then we can create an emplyee object (without adding him to the list)
        }

        static TGCEmployeeSalaryInfo GetSalaryInfo(TGCEmployeeType empType)      //A method for getting the salary info about a certain employee type from the user
        {
            TGCEmployeeSalaryInfo salInfo = new TGCEmployeeSalaryInfo(empType);
            switch (empType)                                                         //A switch to see what the type is so that the correct questions could be asked
            {
                case (TGCEmployeeType)0:                                            //if it is a secretary than ask for hourly wage and number of hours
                    Console.WriteLine("Please Enter Hourly Wage");
                    salInfo.hourlyWage = float.Parse(Console.ReadLine());
                    Console.WriteLine("Please Enter Number of Hours Worked");
                    salInfo.monthlyHours = int.Parse(Console.ReadLine());
                    break;
                case (TGCEmployeeType)1:                                            //if it is a sales person than ask for base salary, number of sales and bomus per sale
                    Console.WriteLine("Please Enter Base Salary");
                    salInfo.baseSalary = float.Parse(Console.ReadLine());
                    Console.WriteLine("Please Enter Number of Sales");
                    salInfo.numSales = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please Enter Bonus per Sale");
                    salInfo.salaryBonus = float.Parse(Console.ReadLine());
                    break;
                case (TGCEmployeeType)2:                                            //if it is a manager than ask for the base salary. The bonus is currently constant as part of the salary info struct  
                    Console.WriteLine("Please Enter Base Salary");
                    salInfo.baseSalary = float.Parse(Console.ReadLine());
                    break;
                case (TGCEmployeeType)3:                                            //if it is a top manager than ask for the base salary. The bonus is currently constant as part of the salary info struct
                    Console.WriteLine("Please Enter Base Salary");
                    salInfo.baseSalary = float.Parse(Console.ReadLine());
                    break;
            }

            return salInfo;
        }
    }
    class TGCEmployee                                                  //An employee class which includes all the information about an employee, ways to retrieve and set the info, and calculate its salary
    {
        string firstName;
        string familyName;
        DateTime birthDate;
        TGCEmployeeType employeeType;
        TGCEmployeeSalaryInfo employeeSalaryInfo;

        public TGCEmployee(string first, string family, DateTime bDay)  //first constructor which creates an employee without his salary info and type.
        {
            firstName = first;
            familyName = family;
            birthDate = bDay;
        }

        public TGCEmployee(string first, string family, DateTime bDay, TGCEmployeeType empType, TGCEmployeeSalaryInfo salInfo) //second constructor which creates an employee with all info
        {
            firstName = first;
            familyName = family;
            birthDate = bDay;
            employeeType = empType;
            employeeSalaryInfo = salInfo;
        }

        public string FirstName      //property method for getting the first name
        {
            get
            {
                return this.firstName;
            }
        }
        public string FamilyName        //property method for getting the last name
        {
            get
            {
                return this.familyName;
            }
        }
        public DateTime BirthDate      //property method for getting the birth date
        {
            get
            {
                return this.birthDate;
            }
        }

        public TGCEmployeeType EmployeeType //property method for getting the type of employee or setting it (in case it changed)
        {
            get
            {
                return this.employeeType;
            }

            set
            {
                this.employeeType = value;
            }
        } 
        public TGCEmployeeSalaryInfo SalaryInfo //property method for setting new salary information for the employee
        {
            set
            {
                this.employeeSalaryInfo = value;
            }
        }
        public float CalcSalary()              //method for calculating the employee's salary
        {
            float salary = 0;
            switch (employeeType)
            {
                case (TGCEmployeeType)0:        //if employee is a secretary than multiply wage per hour by hours worked
                    salary = (employeeSalaryInfo.hourlyWage) * (employeeSalaryInfo.monthlyHours);
                    break;
                case (TGCEmployeeType)1:        //if employee is a sales person than multiply number of sales by bonus per sale and add that to the base salary
                    salary = ((employeeSalaryInfo.baseSalary) + (employeeSalaryInfo.numSales * (employeeSalaryInfo.salaryBonus)));
                    break;
                case (TGCEmployeeType)2:        //if employee is a manager than add the bonus to the base salary
                    salary = (employeeSalaryInfo.baseSalary) + (employeeSalaryInfo.salaryBonus);
                    break;
                case (TGCEmployeeType)3:        //if employee is a top manager than add the bonus to the base salary
                    salary = (employeeSalaryInfo.baseSalary) + (employeeSalaryInfo.salaryBonus);
                    break;
            }
            return salary;
        }
    }
    class TGCEmployeeArray                    //A class for dealing with a list of employees
    {
        private ArrayList employees;            //class is based on an array list

        public TGCEmployeeArray()              //and constructor just creates an empty array list
        {
            employees = new ArrayList();
        }

        public void Add(TGCEmployee emp)        //when adding an employee to the list it is 
        {
            employees.Add(emp);              //just added to the array list

        }

        public bool Contains(TGCEmployee emp)  //a method for checking if an employee is contained in the list.
        {
            foreach (TGCEmployee e in employees)    //going through the list and if the same employee (same first name, last name and birthday) is found than he is contained in the list
                if ((emp.FirstName.ToLower() == e.FirstName.ToLower()) && (emp.FamilyName.ToLower() == e.FamilyName.ToLower()) && (emp.BirthDate == e.BirthDate))
                    return true;

            return false;
        }

        public void Remove(TGCEmployee emp)   //a method for removing an employee from the list.
        {
            foreach (TGCEmployee e in employees)    //if same employee (same first name, same last name and birthdate) is found in the list
                if ((emp.FirstName.ToLower() == e.FirstName.ToLower()) && (emp.FamilyName.ToLower() == e.FamilyName.ToLower()) && (emp.BirthDate == e.BirthDate))
                {
                    employees.Remove(e);            //then it can be removed.
                    break;
                }


        }

        public TGCEmployeeType Find(TGCEmployee emp)    //a method for finding an employee in the list and returning his employee type
        {
            foreach (TGCEmployee e in employees)
                if ((emp.FirstName.ToLower() == e.FirstName.ToLower()) && (emp.FamilyName.ToLower() == e.FamilyName.ToLower()) && (emp.BirthDate == e.BirthDate))
                    return e.EmployeeType;
            return (TGCEmployeeType)0;

        }
        public void Replace(TGCEmployee emp, TGCEmployeeType emType, TGCEmployeeSalaryInfo salInfo) //a method for replacing an employees info. only type and salary info could be replaced
        {
            foreach (TGCEmployee e in employees)    //finding employee to replace
                if ((emp.FirstName.ToLower() == e.FirstName.ToLower()) && (emp.FamilyName.ToLower() == e.FamilyName.ToLower()) && (emp.BirthDate == e.BirthDate))
                {
                    e.EmployeeType = emType;        //replacing type
                    e.SalaryInfo = salInfo;      //replacing salary info
                    break;
                }
        }

        public void Print()                      //a method for printing all employees in the list icluding name, birthdate, type and salary.
        {
            Console.WriteLine("Family Name\tFirst Name\tBirth Date\tWorker Type\tSalary");
            Console.WriteLine("-----------\t----------\t----------\t-----------\t------");
            foreach (TGCEmployee e in employees)
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", e.FamilyName.PadRight(11), e.FirstName.PadRight(10), e.BirthDate.ToShortDateString(), e.EmployeeType.ToString().PadRight(11), e.CalcSalary());
            Console.WriteLine();
        }
    }
}