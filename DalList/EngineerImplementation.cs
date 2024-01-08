
namespace Dal;
using DalFacade.DalApi;
using DalFacade.DO;
using System.Collections.Generic;

public class EngineerImplementation : IEngineer
{
    public int Create(Engineer item)
    {
        
    }

    public void Delete(int id)
    {
        
    }

    public Engineer? Read(int ID)
    {
        foreach (Engineer? Eng in DataSource.Engineers)
        {
            if (Eng.Id == ID)
            {
                return Eng;
            }
            return null;
        }
    }

    public List<Engineer> ReadAll()
    {
        return new List<Engineer>(DataSource.Engineers);
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
                throw new ArgumentException($"Object  with ID {updatedObjectId} does not exist.");
            }
        }
    }
}
