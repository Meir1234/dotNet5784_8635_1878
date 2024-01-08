
namespace Dal;


internal static class DataSource
{
    internal static class Config
    {
        internal const int startTaskid = 1;
        private static int nextTaskid = startTaskid;

        internal static int NextTaskid => nextTaskid++;

        internal const int startEngineerId = 1;
        private static int nextEngineerId = startEngineerId;
        internal static int NextEngineerId { get => nextEngineerId++; }
    }
    internal static List<DalFacade.DO.Engineer> Engineers { get; } = new();
    internal static List<DalFacade.DO.Dependency> Dependencys { get; } = new();

    internal static List<DalFacade.DO.Task> Tasks { get; } = new();

}
