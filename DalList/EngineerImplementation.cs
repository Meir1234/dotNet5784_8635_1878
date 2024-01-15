
namespace Dal;
using DalApi;
using DO;
using System.Linq;

internal class EngineerImplementation : IEngineer
{
    public int Create(Engineer item)
    {
        if (Read(item.Id) is not null)
            throw new DalAlreadyExistsException($"Engineer with ID={item.Id} already exists");
        DataSource.Engineers.Add(item);
        return item.Id;
    }

    public void Delete(int id)
    {
        if (Read(id) is null)
            throw new DalDoesNotExistException($"Engineer with ID={id} does not exists");
        DataSource.Engineers.RemoveAll(Engineer => Engineer.Id == id);
    }

    //public Engineer? Read(int ID)
    //{
    //    foreach (Engineer? Eng in DataSource.Engineers)
    //    {
    //        if (Eng.Id == ID)
    //        {
    //            return Eng;
    //        }   
    //    }
    //    return null;
    //}
    public Engineer? Read(int ID)
    {
        Engineer? foundEngineer = DataSource.Engineers.FirstOrDefault(engineer => engineer.Id == ID);
        return foundEngineer;
    }

    public Engineer? Read(Func<Engineer, bool> filter)
    {
        return DataSource.Engineers.FirstOrDefault(filter);
    }

    //public List<Engineer> ReadAll()
    //{
    //    return DataSource.Engineers;
    //}
    public IEnumerable<Engineer?> ReadAll(Func<Engineer, bool>? filter = null)
    {
        if (filter == null)
            return DataSource.Engineers.Select(item => item);
        else
            return DataSource.Engineers.Where(filter);
    }

    public void Update(Engineer item)
    
    {
        {
            int updatedObjectId = item.Id;
            bool found = false;

            foreach (Engineer? obj in DataSource.Engineers)
            {
                if (obj.Id == updatedObjectId)
                {
                    bool v = DataSource.Engineers.Remove(obj);
                    DataSource.Engineers.Add(item);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                throw new DalDoesNotExistException($"Engineer with ID {updatedObjectId} does not exist.");
            }
        }
    }
}
