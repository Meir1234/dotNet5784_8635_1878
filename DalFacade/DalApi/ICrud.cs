
namespace DalFacade.DalApi
{
    public interface ICrud<T> where T : class
    {
        public int Create(T item);
        public T? Read(int id);
        T? Read(Func<T, bool> filter); // stage 2

        //public List<T> ReadAll();
        IEnumerable<T?> ReadAll(Func<T, bool>? filter = null); // stage 2

        public void Update(T item);
        public void Delete(int id);
    }

}
