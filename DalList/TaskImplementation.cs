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
        DataSource.Tasks.RemoveAll(task => task.id == id);
    }

    public Task? Read(int id)
    {

        foreach (Task? tas in DataSource.Tasks)
        {
            if (tas.id == id)
            {
                return tas;
            }
        }
        return null;

    }

    public void Update(Task item)
    {
        {
            int updatedObjectId = item.id;
            bool found = false;

            foreach (Task? obj in DataSource.Tasks)
            {
                if (obj.id == updatedObjectId)
                {
                    DataSource.Tasks.Remove(obj);
                    DataSource.Tasks.Add(item);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                throw new ArgumentException($"Object  with ID {updatedObjectId} does not exist.");
            }
        }
    }
    public List<Task> ReadAll()
    {
        return new List<Task>(DataSource.Tasks);
    }
}


