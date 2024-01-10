
namespace Dal;
using DO;

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
    internal static List<Engineer> Engineers { get; } = new();
    internal static List<Dependency> Dependencys { get; } = new();
    internal static List<Task> Tasks { get; } = new();

}
