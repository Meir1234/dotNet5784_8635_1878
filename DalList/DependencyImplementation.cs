
namespace Dal;
using DalApi;
using DO;
using System.Linq;

internal class DependencyImplementation : IDependency
{

    public int Create(Dependency item)
    {
        int idNum = DataSource.Config.NextDependencyId;

        // בדיקה אם יש תלות קיימת עם אותו Id
        //bool dependencyExists = DataSource.Dependencys.Any(existingDependency => existingDependency.Id == item.Id);
        //if (dependencyExists)
        //{
        //    throw new Exception($"Dependency with ID={item.Id} already exists");
        //}
        DataSource.Dependencys.Add(item with { Id = idNum });
        return idNum;
    }
    public void Delete(int id)
    {
        List<Dependency> dependenciesToDelete = DataSource.Dependencys
            .Where(dependency => dependency.Id == id)
            .ToList();

        if (dependenciesToDelete.Count == 0)
            throw new DalDoesNotExistException($"Dependency with ID={id} does not exists");

        foreach (Dependency dependency in dependenciesToDelete)
        {
            DataSource.Dependencys.Remove(dependency);
        }
    }

    //public Dependency? Read(int ID)
    //{
    //    foreach (Dependency? Dep in DataSource.Dependencys)
    //    {
    //        if (Dep.Id == ID)
    //        {
    //            return Dep;
    //        }

    //    }
    //    return null;
    //}
    public Dependency? Read(int ID)//function work with linq
    {
        Dependency? foundDependency = DataSource.Dependencys.FirstOrDefault(dependency => dependency.Id == ID);
        return foundDependency;
    }
    public Dependency? Read(Func<Dependency, bool> filter)
    {
        return DataSource.Dependencys.FirstOrDefault(filter);
    }
    
    //public List<Dependency> ReadAll()
    //{
    //    return DataSource.Dependencys;
    //}
    public IEnumerable<Dependency?> ReadAll(Func<Dependency, bool>? filter = null)
    {
        if (filter == null)
            return DataSource.Dependencys.Select(item => item);
        else
            return DataSource.Dependencys.Where(filter);
    }

    public void Update(Dependency item)
    {
        {
            int updatedObjectId = item.Id;
            bool found = false;

            foreach (Dependency? obj in DataSource.Dependencys)
            {
                if (obj.Id == updatedObjectId)
                {
                    DataSource.Dependencys.Remove(obj);
                    DataSource.Dependencys.Add(item);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                throw new DalDoesNotExistException($"Dependency with ID {updatedObjectId} does not exist.");
            }
        }
    }
}

