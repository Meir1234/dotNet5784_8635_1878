// See https://aka.ms/new-console-template for more information
namespace DalTest;
using Dal;

using DalApi;
using DalFacade.DalApi;
using DO;
using System.Reflection.Emit;
using System.Xml.Linq;

internal class Program

{
    private static IEngineer? s_dalEngineer = new EngineerImplementation(); //stage 1
    private static readonly IDependency? s_dalDependency = new DependencyImplementation(); //stage 1
    private static ITask? s_dalTask = new TaskImplementation(); //stage 1
    static void Main(string[] obj)
    {
        try
        {
            Initialization.Do(s_dalEngineer, s_dalTask, s_dalDependency);
            Console.WriteLine("Choose an entity:");
            Console.WriteLine("1. Engineer");
            Console.WriteLine("2. Dependency");
            Console.WriteLine("3. Task");
            Console.Write("Enter your choice: ");
            int entityChoice = Console.Read();

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
        catch (Exception exp)
        {
            Console.WriteLine(exp);
        }

        

    }
    private static void DisplayEngineerOptions()
    {
        Console.WriteLine("Engineer options:");
        Console.WriteLine("1. Exit engineer menu");
        Console.WriteLine("2. Add new engineer");
        Console.WriteLine("3. Display engineer by ID");
        Console.WriteLine("4. Display all engineers");
        Console.WriteLine("5. Update engineer details");
        Console.WriteLine("6. Delete engineer");

        Console.Write("Enter your choice: ");
        int choice = Console.Read();

        // Implement logic for engineer options...

        PerformEngineerActions(choice);
    }

    public static void PerformEngineerActions(int choice)
    {
        switch (choice)
        {
            case 1:
                Exit();
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

    public static void DisplayTaskOptions()
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





    public static void ExitEngineerMenu()
    public static void Exit()
    {
        Environment.Exit(0);
    }
    private static void AddNewEngineer()
    {
        Console.WriteLine("Enter Engineer Details:");

        // User input for engineer details
        Console.Write("Id: ");
        int id = Console.Read();

        Console.Write("Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Email: ");
        string email = Console.ReadLine()!;

        Console.Write("Level: Beginner, AdvancedBeginner, Intermediate, Advanced, Expert. chooce 1-5");
        Enum level = (Level)(Console.Read());

        Console.Write("Cost: ");
        double cost = double.Parse(Console.ReadLine()!);

        // Create an Engineer object from the user input
        Engineer newEngineer = new(id, name, email, level, cost);
        s_dalEngineer!.Create(newEngineer);
    }

    private static void DisplayEngineerByID()
    {
        Console.WriteLine("Enter Engineer ID: ");
        int id = int.Parse(Console.ReadLine()!);
        Console.WriteLine(s_dalEngineer!.Read(id));
    }

    private static void DisplayAllEngineers()
    {
        Console.WriteLine(s_dalEngineer!.ReadAll());
    }

    private static void UpdateEngineerDetails()
    {
        Console.WriteLine("Enter Engineer ID");
        int id = Console.Read();

        Console.Write("Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Email: ");
        string email = Console.ReadLine()!;

        Console.Write("Level: Beginner, AdvancedBeginner, Intermediate, Advanced, Expert. chooce 1-5");
        Enum level = (Level)(Console.Read());

        Console.Write("Cost: ");
        double cost = double.Parse(Console.ReadLine()!);

        // Create an Engineer object from the user input
        Engineer newEngineer = new(id, name, email, level, cost);
        s_dalEngineer!.Update(newEngineer);

    }
    private static void DeleteEngineer()
    {
        Console.WriteLine("Enter Engineer ID:");
        int id = Console.Read();
        s_dalEngineer!.Delete(id);
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
        int choice = Console.Read();

        PerformDependencyAction(choice);
        return;
    }

    public static void PerformDependencyAction(int choice)
    {
        switch (choice)
        {
            case 1:
                Exit();
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

    private static void AddNewDependency()
    {
        Console.WriteLine("Enter Dependent Task ID");
        int depTask = Console.Read();
        Console.WriteLine("Enter Dependent On Task ID");
        int depOnTask = Console.Read();
        Dependency newDep = new(0, depTask, depOnTask);
        s_dalDependency!.Create(newDep);
    }
    private static void DisplayDependencyByID() 
    {
        Console.WriteLine("Enter Dependency ID:");
        int id = Console.Read();
        Console.WriteLine(s_dalDependency!.Read(id));
    }
    private static void DisplayAllDependencies()
    {
        Console.WriteLine(s_dalDependency!.ReadAll());
    }
    private static void UpdateDependencyDetails()
    {
        Console.WriteLine("Enter Dependent Task ID");
        int depTask = Console.Read();
        Console.WriteLine("Enter Dependent On Task ID");
        int depOnTask = Console.Read();
        Dependency newDep = new(0, depTask, depOnTask);
        s_dalDependency!.Update(newDep);
    }
    private static void DeleteDependency() 
    {
        Console.WriteLine("Enter Engineer ID:");
        int id = Console.Read();
        s_dalEngineer!.Delete(id);
    }


    public static void DisplayTaskOptions()
    {
        Console.WriteLine("Task options:");
        Console.WriteLine("1. Exit task menu");
        Console.WriteLine("2. Add new task");
        Console.WriteLine("3. Display task by ID");
        Console.WriteLine("4. Display all tasks");
        Console.WriteLine("5. Update task details");
        Console.WriteLine("6. Delete task");


    private static void ExitTaskMenu() { /* Implement exit logic */  Environment.Exit(0); }
        // Implement logic for task options...
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






    //    double cost;
    //    string? name, email;
    //    DO.EngineerExperience level;
    //    Console.WriteLine("Enter the engineer's id:");
    //    id = Console.Read();
    //    Console.WriteLine("Enter the salary:");
    //    cost = Console.Read();
    //    Console.WriteLine("Enter the engineer's name:");
    //    name = Console.ReadLine();
    //    Console.WriteLine("Enter the engineer's email:");
    //    email = Console.ReadLine();
    //    Console.WriteLine("Enter the engineer's level:");
    //    level = (DO.EngineerExperience)Console.Read();


    //    Engineer New = new Engineer(id, cost, name, email, level);
    //    try
    //    {
    //        s_Engineer!.Create(New);
    //    }
    //    catch (Exception e)
    //    {
    //        Console.WriteLine(e);
    //    }
    //}
    //public static void UpdateEngineer(Engineer E)
    //{
    //    int id = 0;
    //    double cost = 0;
    //    string? name, email;
    //    DO.EngineerExperience level;
    //    Console.WriteLine("Enter the new engineer's data:");
    //    id = Console.Read();
    //    cost = Console.Read();
    //    name = Console.ReadLine();
    //    email = Console.ReadLine();
    //    level = (DO.EngineerExperience)Console.Read();

    //}
    //}






    private static void ExitTaskMenu() { /* Implement exit logic */  }

    private static void AddNewTask()
    { /* Implement add task logic */
        // Get input for all variables
        Console.WriteLine("Enter Task ID:");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Alias:");
        string? Alias = Console.ReadLine();

        Console.WriteLine("Enter Description:");
        string? Description = Console.ReadLine();

        Console.WriteLine("Enter Created At Date (yyyy-MM-dd):");
        DateTime CreatedAtDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter Required Effort Time (in hours):");
        TimeSpan RequiredEffortTime = TimeSpan.FromHours(double.Parse(Console.ReadLine()));

        Console.WriteLine("Is this a milestone? (true/false):");
        bool IsMilestone = bool.Parse(Console.ReadLine());

        Console.WriteLine("Enter Start Date (yyyy-MM-dd):");
        DateTime StartDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter Deadline Date (yyyy-MM-dd):");
        DateTime DeadlineDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter Complete Date (yyyy-MM-dd) if applicable, otherwise press Enter:");
        DateTime? CompleteDate = null;
        string userInput = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(userInput))
        {
            CompleteDate = DateTime.Parse(userInput);
        }

        Console.WriteLine("Enter Deliverables:");
        string? Deliverables = Console.ReadLine();

        Console.WriteLine("Enter Engineer ID:");
        int EngineerId = Console.Read()!;

        Console.WriteLine("Enter Level of Hardness (integer value):");
        Level hardness;

        hardness = (Level)Enum.Parse(typeof(Level), Console.ReadLine()!);

    // Create Task object using the provided input
    Task newTask = new Task(id, Alias, Description, CreatedAtDate, RequiredEffortTime, IsMilestone,
                             StartDate, DeadlineDate, CompleteDate, Deliverables, EngineerId, hardness);
        s_dalTask!.Create(newTask);
    



  
        // Create Task object using the provided input
        Task newTask = new Task(id, Alias, Description, CreatedAtDate, RequiredEffortTime, IsMilestone,
                                 StartDate, DeadlineDate, CompleteDate, Deliverables, EngineerId, hardness);
        s_dalTask!.Create(newTask);
    }

   

    private static void DisplayTaskByID() { /* Implement display by ID logic */
        Console.WriteLine("Enter task ID: ");
        int id = int.Parse(Console.ReadLine()!);
        Task task = Tasks.Read(t => t.Id == id);
    if (task != null)
    {
        Console.WriteLine($"Task ID: {task.id}");
        Console.WriteLine($"Alias: {task.Alias}");
        Console.WriteLine($"Description: {task.Description}");
        Console.WriteLine($"CreatedAtDate: {task.CreatedAtDate}");
        Console.WriteLine($"RequiredEffortTime: {task.RequiredEffortTime}");
        Console.WriteLine($"IsMilestone: {task.IsMilestone}");
        Console.WriteLine($"StartDate: {task.StartDate}");
        Console.WriteLine($"DeadlineDate: {task.DeadlineDate}");
        Console.WriteLine($"CompleteDate: {task.CompleteDate}");
        Console.WriteLine($"Deliverables: {task.Deliverables}");
        Console.WriteLine($"EngineerId: {task.EngineerId}");
        Console.WriteLine($"Hardness: {task.Hardness}");
    }
    else
    {
        Console.WriteLine("Task not found!");
    }
}
private static void DisplayAllTasks() { /* Implement display all logic */
    Console.WriteLine(s_dalTask!.ReadAll());
    
        Task task = Tasks.Read(t => t.Id == taskId);
        if (task != null)
        {
            Console.WriteLine($"Task ID: {task.id}");
            Console.WriteLine($"Alias: {task.Alias}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"CreatedAtDate: {task.CreatedAtDate}");
            Console.WriteLine($"RequiredEffortTime: {task.RequiredEffortTime}");
            Console.WriteLine($"IsMilestone: {task.IsMilestone}");
            Console.WriteLine($"StartDate: {task.StartDate}");
            Console.WriteLine($"DeadlineDate: {task.DeadlineDate}");
            Console.WriteLine($"CompleteDate: {task.CompleteDate}");
            Console.WriteLine($"Deliverables: {task.Deliverables}");
            Console.WriteLine($"EngineerId: {task.EngineerId}");
            Console.WriteLine($"Hardness: {task.Hardness}");
        }
        else
        {
            Console.WriteLine("Task not found!");
        }
    }
    private static void DisplayAllTasks()
    { 
        Console.WriteLine(s_dalTask!.ReadAll());
    }

    private static void UpdateTaskDetails()
    { /* Implement update logic */ /* Implement add task logic */
        // Get input for all variables
        Console.WriteLine("Enter Task ID:");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Alias:");
        string? Alias = Console.ReadLine();

        Console.WriteLine("Enter Description:");
        string? Description = Console.ReadLine();

        Console.WriteLine("Enter Created At Date (yyyy-MM-dd):");
        DateTime CreatedAtDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter Required Effort Time (in hours):");
        TimeSpan RequiredEffortTime = TimeSpan.FromHours(double.Parse(Console.ReadLine()));

        Console.WriteLine("Is this a milestone? (true/false):");
        bool IsMilestone = bool.Parse(Console.ReadLine());

        Console.WriteLine("Enter Start Date (yyyy-MM-dd):");
        DateTime StartDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter Deadline Date (yyyy-MM-dd):");
        DateTime DeadlineDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter Complete Date (yyyy-MM-dd) if applicable, otherwise press Enter:");
        DateTime? CompleteDate = null;
        string userInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(userInput))
        {
            CompleteDate = DateTime.Parse(userInput);
        }
    private static void UpdateTaskDetails() { /* Implement update logic */ }
    private static void DeleteTask(Task tasks)
    {
        Console.WriteLine("Enter Task ID:");
        int id = Console.Read();
        s_dalTask!.Delete(id);
    }
        private static void UpdateTaskDetails() { /* Implement update logic */ 
        Console.WriteLine("Enter Deliverables:");
        string? Deliverables = Console.ReadLine();

        Console.WriteLine("Enter Engineer ID:");
        int EngineerId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Level of Hardness (integer value):");
        Level hardness;

        hardness = (Level)Enum.Parse(typeof(Level), Console.ReadLine());

        // Create Task object using the provided input
        Task newTask = new Task(id, Alias, Description, CreatedAtDate, RequiredEffortTime, IsMilestone,
                                 StartDate, DeadlineDate, CompleteDate, Deliverables, EngineerId, hardness);
        s_dalTask!.Update(newTask);
    }

    private static void DeleteTask(Task tasks) { /* Implement delete logic */
    tasks.Delete(tasks.id);
    }
}


  
  





