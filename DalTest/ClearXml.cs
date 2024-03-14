using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalTest;
using DalApi;
using DO;

internal class ClearXml
{
    static readonly IDal? s_dal = Factory.Get;

    private static void ClearDependencies()
    {
        s_dal.Dependency.Clear();
    }

    private static void ClearEngineers()
    {
        s_dal.Engineer.Clear();

    }

    private static void ClearTasks()
    {
        s_dal.Task.Clear();
    }

    public static void Do()
    {
        ClearDependencies();
        ClearEngineers();
        ClearTasks();
    }
}
