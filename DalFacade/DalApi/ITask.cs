

using DalFacade.DO;


namespace DalFacade.DalApi;
using DO;
public interface ITask
{
    public int Create(Task item);
    public Task? Read(int Id);
    public List<Task> ReadAll()
    {
        return new List<Task>(DataSource.Ts);
    }
    public void Update(Task item);
    public void Delete(int id);
}
