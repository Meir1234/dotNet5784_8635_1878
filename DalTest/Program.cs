// See https://aka.ms/new-console-template for more information
namespace DalTest;

using Dal;
using DalApi;
using DO;



static class Program
{
    private static IEngineer? s_dalEngineer = new EngineerImplementation(); //stage 1
    private static IDependency? s_dalDependency = new DependencyImplementation(); //stage 1
    private static ITask? s_dalTask = new TaskImplementation(); //stage 1
    static void Main(string[] args)
    {
        Initialization.Do(s_dalEngineer, s_dalTask, s_dalDependency);
        static void mainMnue()
        {
            int choice;
            Console.WriteLine("Enter number to choose one of the following:\n" +
                 "0:Exit\n" +
                 "1:Engineer\n" +
                 "2:Task\n" +
                 "3:Dependency\n");

            choice = Console.Read();

            switch (choice)
            {

                case 0:
                    return;
                case 1:

            }

        }
      
    }
}


