using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;

public interface IEngineer
{
    public IEnumerable<BO.Engineer> ReadAll(Func<Engineer,bool> filter = null);
    public int Create(BO.Engineer engineer);

    public BO.Engineer? Read(int Id);
    public void Update(BO.Engineer item);
    public void Delete(int id);
}
