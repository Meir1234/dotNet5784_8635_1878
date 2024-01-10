// See https://aka.ms/new-console-template for more information
using Dal;
using DalFacade.DO;

Console.WriteLine("Hello, World!");
 
class Program  
    
{
    private static Engineer? s_daEngineer = new EngineerImplementation(); //stage 1
    private static Dependency? s_Dependency = new DependencyImplementation(); //stage 1
    private static Task? s_dalTask = new TaskImplementation(); //stage 1
}
static void Main()
{
}