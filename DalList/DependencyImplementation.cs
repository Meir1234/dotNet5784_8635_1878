
namespace Dal;
using DalApi;
using DO;
using System.Linq;

internal class DependencyImplementation : IDependency
{

    public int Create(Dependency item)
    {
        int idNum = DataSource.Config.NextDependencyId;
        DataSource.Dependenceis.Add(item with { Id = idNum });
        return idNum;
    }
    public void Delete(int id)
    {
        List<Dependency> dependenciesToDelete = DataSource.Dependenceis
            .Where(dependency => dependency.Id == id)
            .ToList();

        if (dependenciesToDelete.Count == 0)
            throw new DalDoesNotExistException($"Dependency with ID={id} does not exists");

        foreach (Dependency dependency in dependenciesToDelete)
        {
            DataSource.Dependenceis.Remove(dependency);
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
        Dependency? foundDependency = DataSource.Dependenceis.FirstOrDefault(dependency => dependency.Id == ID);
        return foundDependency;
    }
    public Dependency? Read(Func<Dependency?, bool>? filter)
    {
        return DataSource.Dependenceis.FirstOrDefault(filter);
    }
    
    public IEnumerable<Dependency?> ReadAll(Func<Dependency?, bool>? filter = null)
    {
        if (filter == null)
            return DataSource.Dependenceis.Select(item => item);
        else
            return DataSource.Dependenceis.Where(filter);
    }

    public void Update(Dependency item)
    {
        {
            int updatedObjectId = item.Id;
            bool found = false;

            foreach (Dependency? obj in DataSource.Dependenceis)
            {
                if (obj.Id == updatedObjectId)
                {
                    DataSource.Dependenceis.Remove(obj);
                    DataSource.Dependenceis.Add(item);
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

