using DalApi;

namespace Dal;
/// <summary>
/// class to provide instances of classes 
/// that implement IDependency, IEngineer, and ITask interfaces
/// </summary>
sealed internal class DalList : IDal
{   
    public static IDal Instance { get; } = new DalList();
    private DalList() { }

    // Property to get an instance of DependencyImplementation
    public IDependency Dependency => new DependencyImplementation();

    // Property to get an instance of EngineerImplementation
    public IEngineer Engineer => new EngineerImplementation();

    // Property to get an instance of TaskImplementation
    public ITask Task => new TaskImplementation();

    public DateTime? StartDate
    {
        set => DataSource.Config.StartDateProject = value;
        get => DataSource.Config.StartDateProject;
    }
    public DateTime? EndDate
    {
        set => DataSource.Config.EndDateProject = value;
        get => DataSource.Config.EndDateProject;
    }

    public DateTime Clock { get; set; } = DateTime.Now;
}
