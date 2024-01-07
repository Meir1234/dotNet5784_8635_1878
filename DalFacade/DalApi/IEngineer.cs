

using DalFacade.DO;

namespace DalFacade.DalApi;

public interface IEngineer
{
    public int Create(Engineer item);
    public Engineer? Read(int Id);
    public List<Engineer> ReadAll()
    {
        return new List<Engineer>(DataSource.Ts);
    }
    public void Update(Engineer item);
    public void Delete(int id);
}
