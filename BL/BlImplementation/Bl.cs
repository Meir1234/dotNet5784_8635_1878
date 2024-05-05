using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation;
using BlApi;

internal class Bl : IBl
{
    public IEngineer Engineer => new EngineerImplementation();

    public ITask Task => new TaskImlementation();

    public ITaskInList TaskInList => new TaskInListImplementation();

    public IEngineerInTask EngineerInTask => new EngineerInTaskImplementation();
}
