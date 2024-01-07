
namespace Dal;


internal static class DataSource
{
    internal static class Config
    {

    }
    internal static List<DalFacade.DO.Engineer> Engineers { get; } = new();
    internal static List<DalFacade.DO.Dependency> Dependency { get; } = new();

}
