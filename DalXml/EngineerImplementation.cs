


namespace Dal;
using DalApi;
using DO;
using System.Data.Common;
using System.Threading.Tasks;

internal class EngineerImplementation : IEngineer
{
    readonly string s_engineers_xml = "engineers";
    public int Create(Engineer item)
    {
        List<Engineer> engineers = XMLTools.LoadListFromXMLSerializer<Engineer>(s_engineers_xml);
        if (Read(item.Id) is not null)
            throw new DalAlreadyExistsException($"Engineer with ID={item.Id} already exists");
        engineers.Add(item);
        XMLTools.SaveListToXMLSerializer(engineers, s_engineers_xml);
        return item.Id;
    }

    public void Delete(int id)
    {
        List<Engineer> engineers = XMLTools.LoadListFromXMLSerializer<Engineer>(s_engineers_xml);
        if (Read(id) is null)
            throw new DalDoesNotExistException($"Engineer with ID={id} does not exists");
        engineers.RemoveAll(Engineer => Engineer.Id == id);
        XMLTools.SaveListToXMLSerializer(engineers, s_engineers_xml);
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
        List<Engineer> engineers = XMLTools.LoadListFromXMLSerializer<Engineer>(s_engineers_xml);
        Engineer? foundEngineer = engineers.FirstOrDefault(engineer => engineer.Id == ID);
        XMLTools.SaveListToXMLSerializer(engineers, s_engineers_xml);
        return foundEngineer;
    }

    public Engineer? Read(Func<Engineer, bool> filter)
    {
        List<Engineer> engineers = XMLTools.LoadListFromXMLSerializer<Engineer>(s_engineers_xml);
        Engineer? foundEngineer = engineers.FirstOrDefault(filter);
        XMLTools.SaveListToXMLSerializer(engineers, s_engineers_xml);
        return foundEngineer;
    }


    public IEnumerable<Engineer?> ReadAll(Func<Engineer, bool>? filter = null)
    {
        List<Engineer> engineers = XMLTools.LoadListFromXMLSerializer< Engineer>(s_engineers_xml);
        if (filter == null)
             engineers.Select(item => item);
        else
            engineers.Where(filter);
        XMLTools.SaveListToXMLSerializer(engineers, s_engineers_xml);
        return engineers;
    }

    public void Update(Engineer item)

    {
        List<Engineer> engineers = XMLTools.LoadListFromXMLSerializer<Engineer>(s_engineers_xml);
        {
            int updatedObjectId = item.Id;
            bool found = false;

            foreach (Engineer? obj in engineers)
            {
                if (obj.Id == updatedObjectId)
                {
                    bool v = engineers.Remove(obj);
                    engineers.Add(item);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                throw new DalDoesNotExistException($"Engineer with ID {updatedObjectId} does not exist.");
            }
            XMLTools.SaveListToXMLSerializer(engineers, s_engineers_xml);
        }
    }
}

