using DalApi;
using System.Diagnostics;

namespace Dal;
/// <summary>
/// class to provide instances of classes 
/// that implement IDependency, IEngineer, and ITask interfaces
/// </summary>
sealed internal class DalXml : IDal
{
    public static IDal Instance { get; } = new DalXml();
    private DalXml() { }

    // Property to get an instance of DependencyImplementation
    public IDependency Dependency => new DependencyImplementation();

    // Property to get an instance of EngineerImplementation
    public IEngineer Engineer => new EngineerImplementation();

    // Property to get an instance of TaskImplementation
    public ITask Task => new TaskImplementation();
    public DateTime? StartDate { set => Config.SetDate("StartDate", value); get => Config.GetDate("StartDate"); }
    public DateTime? EndDate { set => Config.SetDate("EndDate", value); get => Config.GetDate("EndDate"); }
    public DateTime Clock { get; set; } = DateTime.Now;

}
