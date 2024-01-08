




namespace DalFacade.DalApi;
using DO;

public interface IDependency
{
  
        public int Create(Dependency item);
        public Dependency? Read(int Id);
        public List<Dependency> ReadAll()
        {
            return new List<Dependency>(DataSource.Ts);
        }
        public void Update(Dependency item);
        public void Delete(int id);
    }


