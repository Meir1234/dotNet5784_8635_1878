using BlApi;

namespace BlImplementation;

internal class Bl : IBl
{
    DalApi.IDal dal = DalApi.Factory.Get;
    public IEngineer Engineer => new EngineerImplementation();
    public ITask Task => new TaskImplemntation();

    public DateTime? StartDate
    {
        get => dal.StartDate;
        set => dal.StartDate = value;
    }
    public DateTime? EndDate
    {
        get => dal.EndDate;
        set => dal.EndDate = value;
    }
    public DateTime Clock
    {
        get => dal.Clock;
        set => dal.Clock = value;
    }
}
