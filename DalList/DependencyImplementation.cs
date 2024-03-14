
namespace Dal;
using DalApi;
using DO;
using System.Linq;
using System.Xml.Linq;


internal class DependencyImplementation : IDependency
{
    readonly string s_config_xml = "data-config";

    public void Clear()
    {
        XElement config = XElement.Load(s_config_xml);

        config.Element("NextDependencyId").SetValue(1);
    }

    public int Create(Dependency item)
    {
        int idNum = DataSource.Config.NextDependencyId;
        DataSource.Dependenceis.Add(item with { Id = idNum });
        return idNum;
    }
    public void Delete(int id)
    {
        List<Dependency> dependenciesToDelete = (from dep in DataSource.Dependenceis
                                                  where dep.Id == id
                                                  select dep).ToList();

        if (dependenciesToDelete.Count == 0)
            throw new DalDoesNotExistException($"Dependency with ID={id} does not exists");


        foreach (Dependency dependency in dependenciesToDelete)
        {
            DataSource.Dependenceis.Remove(dependency);
        }
    }
    public Dependency? Read(int ID)
    {
        Dependency? foundDependency = DataSource.Dependenceis.FirstOrDefault(dependency => dependency.Id == ID);
        return foundDependency;
    }
    public Dependency? Read(Func<Dependency?, bool> filter)
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

