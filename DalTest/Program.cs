// See https://aka.ms/new-console-template for more information
namespace DalTest;
using Dal;
using DalApi;

using DO;
using System.Xml;

internal class Program
{

    //static readonly IDal s_dal = new DalList();
    static readonly IDal s_dal = Factory.Get;

    //public static object? Do { get; private set; }

    public static void Main(string[] obj)
    {
        try
        {
            Console.WriteLine("Would you like to create Initial data? (Y/N)"); //stage 3
            string? ans = Console.ReadLine() ?? throw new FormatException("Wrong input"); //stage 3
            if (ans == "Y") //stage 3
                Initialization.Do();
            MainMenu();
        }
        catch (Exception exp)
        {
            Console.WriteLine(exp);
            MainMenu();
        }
    }

    static void MainMenu()
    {

        Console.WriteLine("Choose an entity:");
        Console.WriteLine("1. Engineer");
        Console.WriteLine("2. Dependency");
        Console.WriteLine("3. Task");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice: ");
        int entityChoice = int.Parse(Console.ReadLine()!);

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
            case 4:
                Exit();
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
        MainMenu();
    }


    public static void Exit()
    {
        ClearXml.Do();

        Environment.Exit(0);
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
        //int choice = Console.Read() - 48;

        int choice = int.Parse(Console.ReadLine());

        // Implement logic for engineer options...

        PerformEngineerActions(choice);
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
        PerformTaskAction(choice);
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
        int choice = int.Parse(Console.ReadLine()!);

        PerformDependencyAction(choice);
        return;
    }


    public static void PerformEngineerActions(int choice)
    {
        switch (choice)
        {
            case 1:
                MainMenu();
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
    public static void PerformTaskAction(int choice)
    {
        switch (choice)
        {
            case 1:
                MainMenu();
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
    public static void PerformDependencyAction(int choice)
    {
        switch (choice)
        {
            case 1:
                MainMenu();
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


    private static void AddNewEngineer()
    {
        Console.WriteLine("Enter Engineer Details:");

        // User input for engineer details
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine()!);

        Console.Write("Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Email: ");
        string email = Console.ReadLine()!;

        Console.Write("Level: Beginner, AdvancedBeginner, Intermediate, Advanced, Expert. choice 1-5");
        int _level = int.Parse(Console.ReadLine()!);
        Level level = (Level)_level;

        Console.Write("Cost: ");
        double cost = double.Parse(Console.ReadLine()!);

        // Create an Engineer object from the user input
        Engineer newEngineer = new(id, name, email, level, cost);
        //s_dalEngineer!.Create(newEngineer);
        try
        {
            s_dal.Engineer!.Create(newEngineer);
        }
        catch (DalAlreadyExistsException msg)
        {  Console.WriteLine(msg); }
    }
    private static void DisplayEngineerByID()
    {
        Console.WriteLine("Enter Engineer ID: ");
        int id = int.Parse(Console.ReadLine()!);
        //Console.WriteLine(s_dalEngineer!.Read(id));
        Console.WriteLine(s_dal.Engineer!.Read(id));

    }
    private static void DisplayAllEngineers()
    {
        //Console.WriteLine(s_dalEngineer!.ReadAll());
        //Console.WriteLine(s_dal.Engineer!.ReadAll());
        //List<Engineer> engineers = s_dalEngineer!.ReadAll();
        IEnumerable<Engineer?> engineers = s_dal!.Engineer.ReadAll();
        foreach (Engineer? engineer in engineers)
            Console.WriteLine(engineer);
    }
    private static void UpdateEngineerDetails()
    {
        Console.WriteLine("Enter Engineer ID");
        int id = int.Parse(Console.ReadLine()!);

        Console.Write("Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Email: ");
        string email = Console.ReadLine()!;

        Console.Write("Level: Beginner, AdvancedBeginner, Intermediate, Advanced, Expert. choice 1-5");
        int _level = int.Parse(Console.ReadLine()!);
        Level level = (Level)_level;

        Console.Write("Cost: ");
        double cost = double.Parse(Console.ReadLine()!);

        // Create an Engineer object from the user input
        Engineer newEngineer = new(id, name, email, level, cost);
        try
        {
            s_dal.Engineer!.Update(newEngineer);
        }
        catch(DalAlreadyExistsException msg)
        { Console.WriteLine(msg); }

    }
    private static void DeleteEngineer()
    {
        Console.WriteLine("Enter Engineer ID:");
        int id = int.Parse(Console.ReadLine()!);
        try
        {
            s_dal.Engineer!.Delete(id);
        }
        catch(DalDoesNotExistException msg) { Console.WriteLine(msg); }
    }


    private static void AddNewDependency()
    {
        Console.WriteLine("Enter Dependent Task ID");
        int depTask = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter Dependent On Task ID");
        int depOnTask = int.Parse(Console.ReadLine()!);
        Dependency newDep = new(0, depTask, depOnTask);
        s_dal.Dependency!.Create(newDep);
    }
    private static void DisplayDependencyByID()
    {
        Console.WriteLine("Enter Dependency ID:");
        int id = int.Parse(Console.ReadLine()!);
        Console.WriteLine(s_dal.Dependency!.Read(id));
    }
    private static void DisplayAllDependencies()
    {
        IEnumerable<Dependency?> engineers = s_dal!.Dependency.ReadAll();
        foreach (Dependency? dep in engineers)
            Console.WriteLine(dep);
    }
    private static void UpdateDependencyDetails()
    {
        Console.WriteLine("Enter Dependency ID");
        int id = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter Dependent Task ID");
        int depTask = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter Dependent On Task ID");
        int depOnTask = int.Parse(Console.ReadLine()!);
        Dependency newDep = new(id, depTask, depOnTask);
        try
        {
            s_dal.Dependency!.Update(newDep);

        }
        catch (DalDoesNotExistException msg)
        {
            Console.WriteLine(msg);
        }
    }
    private static void DeleteDependency()
    {
        Console.WriteLine("Enter Dependency ID:");
        int id = int.Parse(Console.ReadLine()!);
        try
        {
            s_dal.Dependency!.Delete(id);
        }
        catch(DalDoesNotExistException msg) {  Console.WriteLine(msg); }
    }



    private static void AddNewTask()
    { /* Implement add task logic */
        // Get input for all variables
        Console.WriteLine("Enter Task ID:");
        int id = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Alias:");
        string? Alias = Console.ReadLine();

        Console.WriteLine("Enter Description:");
        string? Description = Console.ReadLine();

        Console.WriteLine("Enter Created At Date (yyyy-MM-dd):");
        DateTime CreatedAtDate = DateTime.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Required Effort Time (in hours):");
        TimeSpan RequiredEffortTime = TimeSpan.FromHours(double.Parse(Console.ReadLine()!));

        Console.WriteLine("Is this a milestone? (true/false):");
        bool IsMilestone = bool.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Start Date (yyyy-MM-dd):");
        DateTime StartDate = DateTime.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Deadline Date (yyyy-MM-dd):");
        DateTime DeadlineDate = DateTime.Parse(Console.ReadLine()!);

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
        int EngineerId = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Level of Hardness (integer value):");
        Level hardness;

        hardness = (Level)Enum.Parse(typeof(Level), Console.ReadLine()!);

        // Create Task object using the provided input
        DO.Task newTask = new DO.Task(id,"", Alias, Description, CreatedAtDate,null, RequiredEffortTime, IsMilestone,
                             StartDate, DeadlineDate, CompleteDate, Deliverables, EngineerId, hardness);
        s_dal.Task!.Create(newTask);

    }
    private static void DisplayTaskByID()
    {
        Console.WriteLine("Enter task ID: ");
        int id = int.Parse(Console.ReadLine()!);
        Console.WriteLine(s_dal.Task!.Read(id));
    }
    private static void DisplayAllTasks()
    {
        IEnumerable<Task?> engineers = s_dal!.Task.ReadAll();
        foreach (Task? tas in engineers)
            Console.WriteLine(tas);
    }
    private static void UpdateTaskDetails()
    { /* Implement update logic */ /* Implement add task logic */
        // Get input for all variables
        Console.WriteLine("Enter Task ID:");
        int id = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Alias:");
        string? Alias = Console.ReadLine();

        Console.WriteLine("Enter Description:");
        string? Description = Console.ReadLine();

        Console.WriteLine("Enter Created At Date (yyyy-MM-dd):");
        DateTime CreatedAtDate = DateTime.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Required Effort Time (in hours):");
        TimeSpan RequiredEffortTime = TimeSpan.FromHours(double.Parse(Console.ReadLine())!);

        Console.WriteLine("Is this a milestone? (true/false):");
        bool IsMilestone = bool.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Start Date (yyyy-MM-dd):");
        DateTime StartDate = DateTime.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Deadline Date (yyyy-MM-dd):");
        DateTime DeadlineDate = DateTime.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Complete Date (yyyy-MM-dd) if applicable, otherwise press Enter:");
        DateTime? CompleteDate = null;
        string userInput = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(userInput))
        {
            CompleteDate = DateTime.Parse(userInput);
        }

        //Task task = new(id, Alias, Description, CreatedAtDate, RequiredEffortTime);

        try
        {
            //s_dal.Task.Update(item);

        }
        catch (DalDoesNotExistException msg)
        {
            Console.WriteLine(msg);
        }
    }
    private static void DeleteTask()
    {
        Console.WriteLine("Enter Task ID:");
        int id = int.Parse(Console.ReadLine()!);
        try
        {
            s_dal.Task!.Delete(id);

        }
        catch (DalDoesNotExistException msg)
        {
            Console.WriteLine(msg);
        }
    }

}









