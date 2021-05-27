using System;

namespace calculator
{
    class calculator
    {
        public void Add(int a,int b)
        {
            Console.WriteLine("Sum of {0} and {1} is : {2}", a,b,a+b);
        }
        public void Sub(int a,int b)
        {
            int c;
            if (a > b)
            {
                c = a - b;
                Console.WriteLine("Difference between {0} and {1} is: {2}", a, b, c);
            }
            else
            {
                c = b - a;
                Console.WriteLine("Difference between {0} and {1} is: {2}", b, a, c);
            }
        }
        public void Multi(int a,int b)
        {
            Console.WriteLine("Product of {0} and {1} is : {2}", a, b, a * b);
        }
        public void Divi(int a,int b)
        {
            if ((a == 0) || (b == 0))
            {
                Console.WriteLine("Divide by Zero Error!!");
            }
            else
                Console.WriteLine("Division of {0} and {1} is : {2} ", a, b, a % b);
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            int proceed = 1;
            while (proceed!=0)
            {
                Console.Write("Enter first number:");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter second number:");
                int y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("**MENU DRIVEN**\n1. Addition\n2. Subtraction\n3. Multiplication\n4. Division");
                Console.Write("enter your choice: ");
                int ch= Convert.ToInt32(Console.ReadLine());
                calculator cal = new calculator();
                switch (ch)
                {
                    case 1:
                        cal.Add(x, y);
                        break;
                    case 2:
                        cal.Sub(x, y);
                        break;
                    case 3:
                        cal.Multi(x,y);
                        break;
                    case 4:
                        cal.Divi(x, y);
                        break;
                    default:
                        Console.Write("Invalid Choice");
                        break;
                }
                Console.Write("press 0 to exit else any other number to continue: ");
                proceed= Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
