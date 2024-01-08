
namespace DalFacade.DalApi;
using DalFacade.DO;

using DO;
public interface ITask
{
    public int Create(Task item);
    public Task? Read(int id);
    public List<Task> ReadAll()
    {
        return new List<Task>(DataSource.Ts);
    }
    public void Update(Task item);
    public void Delete(int id);
}
