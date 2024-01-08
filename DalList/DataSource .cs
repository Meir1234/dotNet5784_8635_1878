
namespace Dal;


internal static class DataSource
{
    internal static class Config
    {
        internal const int startTaskid = 1;
        private static int nextTaskid = startTaskid;

        internal static int NextTaskid => nextTaskid++;

        internal const int startDependencyId = 1;
        private static int nextDependencyId = startDependencyId;
        internal static int NextDependencyId { get => nextDependencyId++; }
    }
    internal static List<DalFacade.DO.Engineer> Engineers { get; } = new();
    internal static List<DalFacade.DO.Dependency> Dependencys { get; } = new();
    internal static List<DalFacade.DO.Task> Tasks { get; } = new();

}
