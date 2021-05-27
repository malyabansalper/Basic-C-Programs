using System;

namespace table
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int i, j,k;
            Console.Write("ENTER NUMBER WHOSE TABLE IS TO BE PRINTED : ");
            j = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Table of {0} is as follows: ", j);
            for (i=1;i<11;i++)
            {
                k = j * i;
                Console.WriteLine("{0} * {1} = {2} ", j, i, k);
            }
        }
    }
}
