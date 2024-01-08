

using DalFacade.DO;

namespace DalFacade.DalApi;

public interface IEngineer
{
    public int Create(Engineer item);
    public Engineer? Read(int Id);
    public List<Engineer> ReadAll();
    public void Update(Engineer item);
    public void Delete(int id);
}
