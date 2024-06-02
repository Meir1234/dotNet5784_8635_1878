using BlApi;

namespace BlImplementation;

internal class Bl : IBl
{
    DalApi.IDal dal = DalApi.Factory.Get;
    public IEngineer Engineer => new EngineerImplementation();
    public ITask Task => new TaskImplemntation();


    //public DateTime? StartDate
    //{
    //    get => dal.StartDate;
    //    set => dal.StartDate = value;
    //}
    //public DateTime? EndDate
    //{
    //    get => dal.EndDate;
    //    set => dal.EndDate = value;
    //}
    //private static DateTime s_Clock = DateTime.Now;
    //public DateTime Clock { get { return s_Clock; } private set { s_Clock = value; } }

    //public void ResetClock()
    //{
    //    Clock = DateTime.Now;
    //}
}
