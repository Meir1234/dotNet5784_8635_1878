using System;

namespace targil0
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome8635();
            Welcome1878();
            Console.ReadKey();
        }

        static partial void Welcome1878();
        private static void Welcome8635()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", name);
        }
    }
}