using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;

public interface ITask
{
    public IEnumerable<BO.Task> ReadAll();
    public int Create(BO.Task task );
    public BO.Task? Read(int Id);
    public void Update(BO.Task item);
    public void Delete(int id);
}
