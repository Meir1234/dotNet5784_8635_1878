// See https://aka.ms/new-console-template for more information
namespace DalTest;
using Dal;

using DalApi;
using DO;
using System.Security.Cryptography.X509Certificates;

internal class Program

{
    private static IEngineer? s_dalEngineer = new EngineerImplementation(); //stage 1
    private static IDependency? s_dalDependency = new DependencyImplementation(); //stage 1
    private static ITask? s_dalTask = new TaskImplementation(); //stage 1


    static void Main(string[] obj)
    {
        try
        {
            Initialization.Do(s_dalEngineer, s_dalTask, s_dalDependency);
        }
        catch (Exception exp)
        {
            Console.WriteLine(exp);
        }





       
            Console.WriteLine("Choose an entity:");
            Console.WriteLine("1. Engineer");
            Console.WriteLine("2. Dependency");
            Console.WriteLine("3. Task");

            Console.Write("Enter your choice: ");
            int entityChoice = int.Parse(Console.ReadLine());

            switch (entityChoice)
            {
                case 1:
                    DisplayEngineerOptions();
                    break;
                case 2:
                    DisplayDependencyOptions();
                    break;
                case 3:
                    DisplayTaskOptions();
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        
    }

    private void DisplayEngineerOptions()
        {
            Console.WriteLine("Engineer options:");
            Console.WriteLine("1. Exit engineer menu");
            Console.WriteLine("2. Add new engineer");
            Console.WriteLine("3. Display engineer by ID");
            Console.WriteLine("4. Display all engineers");
            Console.WriteLine("5. Update engineer details");
            Console.WriteLine("6. Delete engineer");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

        // Implement logic for engineer options...

        PerformEngineerAction(choice);
    }

    public static void PerformEngineerAction(int choice)
    {
        switch (choice)
        {
            case 1:
                ExitEngineerMenu();
                break;
            case 2:
                AddNewEngineer();
                break;
            case 3:
                DisplayEngineerByID();
                break;
            case 4:
                DisplayAllEngineers();
                break;
            case 5:
                UpdateEngineerDetails();
                break;
            case 6:
                DeleteEngineer();
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }


    public static void DisplayDependencyOptions()
        {
            Console.WriteLine("Dependency options:");
            Console.WriteLine("1. Exit dependency menu");
            Console.WriteLine("2. Add new dependency");
            Console.WriteLine("3. Display dependency by ID");
            Console.WriteLine("4. Display all dependencies");
            Console.WriteLine("5. Update dependency details");
            Console.WriteLine("6. Delete dependency");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

        PerformDependencyAction(choice);
        return;
    }

    public static void PerformDependencyAction(int choice)
    {
        switch (choice)
        {
            case 1:
                ExitDependencyMenu();
                break;
            case 2:
                AddNewDependency();
                break;
            case 3:
                DisplayDependencyByID();
                break;
            case 4:
                DisplayAllDependencies();
                break;
            case 5:
                UpdateDependencyDetails();
                break;
            case 6:
                DeleteDependency();
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }
    public static  void DisplayTaskOptions()
        {
            Console.WriteLine("Task options:");
            Console.WriteLine("1. Exit task menu");
            Console.WriteLine("2. Add new task");
            Console.WriteLine("3. Display task by ID");
            Console.WriteLine("4. Display all tasks");
            Console.WriteLine("5. Update task details");
            Console.WriteLine("6. Delete task");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            // Implement logic for task options...
        }
    PerformTaskAction(choice);
}
public static void PerformTaskAction(int choice)
{
    switch (choice)
    {
        case 1:
            ExitTaskMenu();
            break;
        case 2:
            AddNewTask();
            break;
        case 3:
            DisplayTaskByID();
            break;
        case 4:
            DisplayAllTasks();
            break;
        case 5:
            UpdateTaskDetails();
            break;
        case 6:
            DeleteTask();
            break;
        default:
            Console.WriteLine("Invalid choice!");
            break;
    }
}

    public static void ExitDependencyMenu() { /* Implement exit logic */ }
    private static void AddNewDependency() { /* Implement add dependency logic */ }
    private static void DisplayDependencyByID() { /* Implement display by ID logic */ }
    private static void DisplayAllDependencies() { /* Implement display all logic */ }
    private static void UpdateDependencyDetails() { /* Implement update logic */ }
    private static void DeleteDependency() { /* Implement delete logic */ }



    private static void ExitTaskMenu() { /* Implement exit logic */ }
    private static void AddNewTask() { /* Implement add task logic */ }
    private static void DisplayTaskByID() { /* Implement display by ID logic */ }
    private static void DisplayAllTasks() { /* Implement display all logic */ }
    private static void UpdateTaskDetails() { /* Implement update logic */ }
    private static void DeleteTask() { /* Implement delete logic */ }

