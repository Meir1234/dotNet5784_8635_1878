namespace Dal;
using DalApi;
using DO;



internal class TaskImplementation : ITask

{
    public int Create(Task item)
    {
        int idNum = DataSource.Config.NextTaskid;
        //if (Read(item.Id) is not null)
        //    throw new Exception($"Task with ID={item.Id} already exists");
        DataSource.Tasks.Add(item with { Id = idNum });
        return idNum;
    }

    public void Delete(int id)
    {
        if (!DataSource.Tasks.Any(task => task.Id == id))
            throw new DalDoesNotExistException($"Task with ID={id} does not exist");
        DataSource.Tasks.RemoveAll(task => task.Id == id);
    }

    //public Task? Read(int id)
    //{

    //    foreach (Task? tas in DataSource.Tasks)
    //    {
    //        if (tas.Id == id)
    //        {
    //            return tas;
    //        }
    //    }
    //    return null;

    //}

    public Task? Read(int id)
    {
        Task? foundTask = DataSource.Tasks.FirstOrDefault(task => task.Id == id);
        return foundTask;
    }
    public Task? Read(Func<Task, bool> filter)
    {
        return DataSource.Tasks.FirstOrDefault(filter);
    }

    public void Update(Task item)
    {
        {
            int updatedObjectId = item.Id;
            bool found = false;

            foreach (Task? obj in DataSource.Tasks)
            {
                if (obj.Id == updatedObjectId)
                {
                    DataSource.Tasks.Remove(obj);
                    DataSource.Tasks.Add(item);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                throw new ArgumentException($"Task with ID {updatedObjectId} does not exist.");
            }
        }
    }
    //public List<Task> ReadAll()
    //{
    //    return new List<Task>(DataSource.Tasks);
    //}
    public IEnumerable<Task?> ReadAll(Func<Task, bool>? filter = null)
    {
        if (filter == null)
            return DataSource.Tasks.Select(item => item);
        else
            return DataSource.Tasks.Where(filter);
    }
}




