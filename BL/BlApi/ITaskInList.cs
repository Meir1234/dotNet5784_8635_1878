using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;

public interface ITaskInList
{
    public List<Task> ReadAll();
    public Task? Build(int id);

    public int Add(BO.Task item);

    public void Update(BO.Task item);

    public void Delete(int id);




}
