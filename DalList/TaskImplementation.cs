namespace Dal;
using DalFacade.DalApi;
using DalFacade.DO;



public class TaskImplementation : ITask

{
    public int Create(Task item)
    {
        int idNum = DataSource.Config.NextTaskid;

        DataSource.Tasks.Add(item with { id = idNum  }) ;
        return idNum;
    }

    public void Delete(int id)
    {
        Task.RemoveAll(item => item.id == id);
    }

    public Task? Read(int id)
    {
        
    }

    public void Update(Task item)
    {
       
    }
}
