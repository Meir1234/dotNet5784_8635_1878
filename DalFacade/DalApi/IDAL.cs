using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi;
/// <summary>
/// IDal represent all the interfaces in DAL
/// every interface have just get() propperty
/// </summary>
public interface IDal
{
    IDependency Dependency { get; }
    IEngineer Engineer { get; }
    ITask Task { get; }

    DateTime? StartDate { set; get; }
    DateTime? EndDate { set; get; }
    DateTime Clock { set; get; }


}

