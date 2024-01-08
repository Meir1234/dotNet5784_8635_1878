
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

    public Engineer? Read(int Id)
    {
        
    }

    public List<Engineer> ReadAll()
    {
        return new List<Engineer>(DataSource.Engineers);
    }

    public void Update(Engineer item)
    {
        
    }
}
