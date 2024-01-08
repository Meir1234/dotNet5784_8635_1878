
namespace DalFacade.DalApi;
using DalFacade.DO;

public interface ITask
{
    public int Create(Task item);
    public Task? Read(int id);
    public List<Task> ReadAll();
    public void Update(Task item);
    public void Delete(int id);
}
