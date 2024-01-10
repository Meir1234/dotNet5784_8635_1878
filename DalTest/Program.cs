// See https://aka.ms/new-console-template for more information
using Dal;
using DalApi;
using DalFacade.DalApi;
using DalFacade.DO;
using DalTest;
using DO;



class Program

{
    private static IEngineer? s_dalEngineer = new EngineerImplementation(); //stage 1
    private static IDependency? s_dalDependency = new DependencyImplementation(); //stage 1
    private static ITask? s_dalTask = new TaskImplementation(); //stage 1
    Initialization.Do(s_dalEngineer, s_dalDependency, s_dalTask);

}


