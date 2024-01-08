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
        ///DataSource.Tasks.Remove(Tasks => task.id == id);
        DataSource.Tasks.RemoveAll(task => task.id == id);
    }

    public Task? Read(int id)
    {
        foreach (Task? Dep in DataSource.Tasks)
        {
            if (Dep.Id == id)
            {
                return Dep;
            }
            return null;
        }
    }

    public void Update(Task item)
    {
        
    }
    public List<Task> ReadAll()
    {
        return new List<Task>(DataSource.Tasks);
    }
}


