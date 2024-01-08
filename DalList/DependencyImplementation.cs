
namespace Dal;
    using DalFacade.DalApi;
using DalFacade.DO;
using System.Collections.Generic;

public class DependencyImplementation : IDependency
{
    public int Create(Dependency item)
    {
        int idNum = DataSource.Config.id;

        DataSource.Dependency.Add(item with { Id = idNum });
        return idNum;
    }

    public void Delete(int id)
    {
        
    }

    public Dependency? Read(int ID)
    {
        foreach (Dependency? Dep in DataSource.Dependencys)
        {
            if (Dep.Id == ID)
            {
                return Dep;
            }
            return null;
        }
    }

    public List<Dependency> ReadAll()
    {
        return new List<Dependency>(DataSource.Dependencys);
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
                throw new ArgumentException($"Object  with ID {updatedObjectId} does not exist.");
            }
        }
    }
}

