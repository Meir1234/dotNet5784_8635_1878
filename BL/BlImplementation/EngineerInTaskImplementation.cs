using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation;

using BlApi;
using BO;
using DalApi;

internal class EngineerInTaskImplementation : IEngineerInTask
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public IEnumerable<EngineerInTask> ReadAll()
    {
        return (from DO.Engineer doEngineer in _dal.Engineer.ReadAll()
                select new BO.EngineerInTask
                {
                    Id = doEngineer.Id,
                    Name = doEngineer.Name
                });
    }
}
