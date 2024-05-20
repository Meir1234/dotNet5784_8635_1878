using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BlApi;

public interface ITask
{
    public IEnumerable<TaskInList> ReadAll(Func<TaskInList, bool>filter = null);
    public int Create(BO.Task task );
    public BO.Task? Read(int Id);
    public void Update(BO.Task item);
    public void Delete(int id);
    public IEnumerable<BO.TaskInGantt> GanttList();
    public void ScheduleTasks(DateTime startDate);
    public IEnumerable<TaskInList> EngineerTasks(int id, bool allMyTasks);
}
