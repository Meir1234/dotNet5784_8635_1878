
namespace Dal;
    using DalFacade.DalApi;
using DalFacade.DO;
using System.Collections.Generic;

public class DependencyImplementation : IDependency
{
    public int Create(Dependency item)
    {
        
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
        
    }
}

