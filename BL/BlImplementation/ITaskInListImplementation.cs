using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation;
using BlApi;
using DalApi;

internal class ITaskInListImplementation : ITaskInList
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public IEnumerable<BO.TaskInList> ReadAll()
    {
        return (from DO.Task doTask in _dal.Task.ReadAll()
                select new BO.TaskInList
                {
                    Id = doTask.Id,
                    Alias = doTask.Alias,
                    Level = (BO.Level)doTask.Hardness
                });
    }
}
