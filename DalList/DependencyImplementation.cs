
namespace Dal;
using DalApi;
using DO;

public class DependencyImplementation : IDependency
{
    public int Create(Dependency item)
    {
        int idNum = DataSource.Config.NextDependencyId;
        if (Read(item.Id) is not null)
            throw new Exception($"Student with ID={item.Id} already exists");
        DataSource.Dependencys.Add(item with { Id = idNum });
        return idNum;
    }

    public void Delete(int id)
    {
        DataSource.Dependencys.RemoveAll(task => task.Id == id);
    }

    public Dependency? Read(int ID)
    {
        foreach (Dependency? Dep in DataSource.Dependencys)
        {
            if (Dep.Id == ID)
            {
                return Dep;
            }

        }
        return null;
    }

    public List<Dependency> ReadAll()
    {
        return DataSource.Dependencys;
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

