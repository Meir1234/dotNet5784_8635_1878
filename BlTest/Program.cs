namespace Bltest;
using BlApi;
using DalTest;
using BO;

internal class Program
{
    static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
    public static void Main(string[] obj)
    {

        try
        {
            Console.Write("Would you like to create Initial data? (Y/N)");
            string? ans = Console.ReadLine() ?? throw new FormatException("Wrong input");
            if (ans == "Y")
                DalTest.Initialization.Do();

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
        Console.WriteLine("2. Task");
        Console.WriteLine("3. TaskInList");
        Console.WriteLine("4. EngineerInTask");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice: ");
        int entityChoice = int.Parse(Console.ReadLine()!);

        switch (entityChoice)
        {
            case 1:
                DisplayEngineerOptions();
                break;
            case 2:
                DisplayTaskOptions();
                break;
            case 3:
                DisplayTaskInListOptions();
                break;
            case 4:
                DisplayEngineerInTaskOptions();
                break;
            case 5:
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
        DalTest.ClearXml.Do();

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
    private static void DisplayEngineerInTaskOptions()
    {
        Console.WriteLine("1. Display all engineers");
        Console.WriteLine("2. back to the main menu");

        Console.Write("Enter your choice: ");

        int choice = int.Parse(Console.ReadLine());

        PerformEngineerInTaskActions(choice);
    }


    private static void DisplayTaskInListOptions()
    {
        Console.WriteLine("1. Display all tasks");
        Console.WriteLine("2. back to the main menu");

        Console.Write("Enter your choice: ");

        int choice = int.Parse(Console.ReadLine());

        PerformTaskInListActions(choice);
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
    private static void PerformEngineerInTaskActions(int choice)
    {
        switch(choice)
        {
            case 1:
                DisplayEngineerInTask();
                break;
            case 2:
                MainMenu();
                break;

        }
    }

 

    private static void PerformTaskInListActions(int choice)
    {
        switch (choice)
        {
            case 1:
                DisplayTaskInList();
                break;
            case 2:
                MainMenu();
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

        Engineer newEngineer = new(id, name, email, level, cost);
        try
        {
            s_bl.Engineer!.Create(newEngineer);
        }
        catch (BlAlreadyExistsException msg)
        { Console.WriteLine(msg); }
    }
    private static void DisplayEngineerByID()
    {
        Console.WriteLine("Enter Engineer ID: ");
        int id = int.Parse(Console.ReadLine()!);
        Console.WriteLine(s_bl.Engineer!.Read(id).ToString());
    }
    private static void DisplayAllEngineers()
    {

        IEnumerable<Engineer?> engineers = s_bl!.Engineer.ReadAll();
        foreach (Engineer? engineer in engineers)
            Console.WriteLine(engineer.ToString());
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
            s_bl.Engineer!.Update(newEngineer);
        }
        catch (BlAlreadyExistsException msg)
        { Console.WriteLine(msg); }

    }
    private static void DeleteEngineer()
    {
        Console.WriteLine("Enter Engineer ID:");
        int id = int.Parse(Console.ReadLine()!);
        try
        {
            s_bl.Engineer!.Delete(id);
        }
        catch (BlDoesNotExistException msg) { Console.WriteLine(msg); }
    }


    private static void AddNewTask()
    {
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
        
        Level hardness = (Level)int.Parse(Console.ReadLine());

        Task newTask = new Task(id, Alias, Description, CreatedAtDate, RequiredEffortTime, IsMilestone,
                             StartDate, DeadlineDate, Deliverables, EngineerId, hardness);
        s_bl.Task!.Create(newTask);

    }
    private static void DisplayTaskByID()
    {
        Console.WriteLine("Enter task ID: ");
        int id = int.Parse(Console.ReadLine()!);
        Console.WriteLine(s_bl.Task!.Read(id).ToString());
    }
    private static void DisplayAllTasks()
    {
        IEnumerable<Task> tasks = s_bl.Task.ReadAll();
        foreach (Task tas in tasks)
            Console.WriteLine(tas.ToString());
    }
    private static void UpdateTaskDetails()
    {
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

        Console.WriteLine("Enter Deliverables:");
        string? Deliverables = Console.ReadLine();

        Console.WriteLine("Enter Engineer ID:");
        int EngineerId = int.Parse(Console.ReadLine()!);

        Level hardness = (Level)int.Parse(Console.ReadLine()!);


        Task newTask = new Task(id, Alias, Description, CreatedAtDate, RequiredEffortTime, IsMilestone,
                     StartDate, DeadlineDate, Deliverables, EngineerId, hardness);
        try
        {
            s_bl.Task.Update(newTask);

        }
        catch (BlDoesNotExistException msg)
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
            s_bl.Task!.Delete(id);

        }
        catch (BlDoesNotExistException msg)
        {
            Console.WriteLine(msg);
        }
    }

    private static void DisplayEngineerInTask()
    {
        IEnumerable<EngineerInTask> engineers = s_bl.EngineerInTask.ReadAll();
        foreach (EngineerInTask eng in engineers)
            Console.WriteLine(eng.ToString());
    }


    private static void DisplayTaskInList()
    {
        IEnumerable<TaskInList> tasks = s_bl.TaskInList.ReadAll();
        foreach (TaskInList tas in tasks)
            Console.WriteLine(tas.ToString());
    }
}






