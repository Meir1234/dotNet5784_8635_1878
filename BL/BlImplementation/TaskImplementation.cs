using BlApi;
using BO;
using DO;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using Task = BO.Task;

namespace BlImplementation;
/// <summary>
/// Implementation of the ITask interface providing CRUD operations for tasks.
/// </summary>
internal class TaskImplemntation : ITask
{
    private readonly DalApi.IDal dal = DalApi.Factory.Get;

    public int Create(Task task)
    {
        try
        {
            if (!IsValid(task))
                throw new BlInvalidData("The data is not valid");//TODO

            DO.Task newTask = new DO.Task()
            {
                Deliverables = task.Deliverables,
                Alias = task.Alias,
                Copmlexity = (DO.Level)task.Complexity,
                Description = task.Description,
                //EngineerId = task.Engineer.ID,
                CreatedDate = task.CreatedDate,
                Remarks = task.Remarks,
                RequiredEffortTime = task.RequiredEffortTime,
            };

            int id = dal.Task.Create(newTask);

            if (task.Dependencies is null)
                return id;

            task.Dependencies.ForEach(dep => dal.Dependency.Create(new DO.Dependency(
                Id: 0,
                DependentTask: task.Id,
                DependsOnTask: dep.Id)));
            return id;
        }
        catch (Exception ex) { throw new BlDoesNotExistException(ex.Message); }//TODO
    }

    public void Delete(int id)
    {
        try
        {
            bool isDepend = dal.Dependency.ReadAll(x => x.DependsOnTask == id).Any();
            if (isDepend)
                throw new BlInvalidData("The data canot be removed");


            dal.Task.Delete(id);
        }
        catch (Exception ex) { throw new Exception(); }
    }

    public Task Read(int id)
    {
        try
        {
            DO.Task task = dal.Task.Read(id) ?? throw new BlDoesNotExistException("the object does not exist");
            DO.Engineer engineer = dal.Engineer.Read(task.EngineerId) ?? new();
            IEnumerable<DO.Dependency> dependencies = dal.Dependency.ReadAll(x => x.DependentTask == id);
            return new Task()
            {
                Id = task.Id,
                Description = task.Description,
                Deliverables = task.Deliverables ?? "",
                Alias = task.Alias,
                Remarks = task.Remarks ?? "",
                RequiredEffortTime = task.RequiredEffortTime,
                Complexity = (BO.Level)task.Copmlexity!,
                CreatedDate = task.CreatedDate,
                ScheduledDate = task.ScheduledDate,
                StartDate = task.StartDate,
                DeadLine = task.StartDate > task.ScheduledDate ?
                    task.StartDate + task.RequiredEffortTime : task.ScheduledDate + task.RequiredEffortTime,
                CompliteDate = task.CompleteDate,
                Status = Tools.GetStatus(task),
                EngineerId = engineer.Id,
                Dependencies = (from dep in dependencies
                                let DOtask = dal.Task.Read(dep.DependsOnTask)
                                select new TaskInList()
                                {
                                    Id = task.Id,
                                    Level = (BO.Level)DOtask.Copmlexity,
                                    Alias = DOtask.Alias,
                                    Status = Tools.GetStatus(DOtask)
                                }).ToList()
            };
        }
        catch (Exception ex) { throw new BlDoesNotExistException(ex.Message); }
    }

    public IEnumerable<TaskInList> ReadAll(Func<TaskInList, bool> filter = null!)
    {
        return (from task in dal.Task.ReadAll()
                select new TaskInList()
                {
                    Id = task.Id,
                    Level = (BO.Level)task.Copmlexity,
                    Alias = task.Alias,
                    Status = Tools.GetStatus(task)
                }).Where(task => filter is null ? true : filter(task));
    }

    public void Update(Task task)
    {
        try
        {
            if (dal.Task.ReadAll().Any(x => x.DeadlineDate is null))
            {
                DO.Task newTask = dal.Task.Read(task.Id)!;
                newTask = newTask with
                {
                    Id = task.Id,
                    Alias = task.Alias,
                    Description = task.Description,
                    RequiredEffortTime = task.RequiredEffortTime,
                    Copmlexity = (DO.Level)task.Complexity!,
                    Deliverables = task.Deliverables,
                    Remarks = task.Remarks,
                    EngineerId = task.EngineerId,
                    StartDate = task.StartDate,
                    ScheduledDate = task.ScheduledDate,
                    DeadlineDate = task.DeadLine,
                    CompleteDate = task.CompliteDate,
                };

                dal.Task.Update(newTask);

                IEnumerable<DO.Dependency?> dependencies = dal.Dependency.ReadAll(x => x.DependentTask == task.Id) ?? new List<DO.Dependency>();

                if (task.Dependencies is null)
                    return;

                task.Dependencies.Where(_new => !dependencies.Any(old => old.DependsOnTask == _new.Id)).ToList().
                    ForEach(_new => dal.Dependency.Create(new DO.Dependency(
                Id: 0,
                    DependentTask: task.Id,
                DependsOnTask: _new.Id)));

                dependencies.Where(old => !task.Dependencies.Any(_new => _new.Id == old!.DependsOnTask)).ToList().
                    ForEach(old => dal.Dependency.Delete(old!.Id));

            }
            else
            {
                DO.Task newTask = dal.Task.Read(task.Id)!;
                newTask = newTask with
                {
                    Alias = task.Alias,
                    Description = task.Description,
                    Deliverables = task.Deliverables,
                    Remarks = task.Remarks,
                    EngineerId = task.EngineerId,
                    StartDate = task.StartDate,
                    CompleteDate = task.CompliteDate
                };
                dal.Task.Update(newTask);
            }

        }
        catch (Exception exe)
        {
            throw new Exception($"Task with ID={task.Id} does not exists", exe);//to check
        }
    }

    public void UpdateDate(int id, DateTime date)
    {
        try
        {
            DO.Task dtask = dal.Task.Read(id) ?? throw new BlDoesNotExistException("the task does not found\n");

            if (dtask.StartDate is not null || !dal.Task.ReadAll().Any(x => x.DeadlineDate is null))
                throw new BlInvalidData("the mossion already started\n");

            IEnumerable<DO.Dependency?> dependList = dal.Dependency.ReadAll(x => x.DependentTask == id) ?? new List<DO.Dependency>();

            var t = from dep in dependList
                    let dependOn = dal.Task.Read(dep.DependsOnTask) ?? throw new BlDoesNotExistException("the object does not exist")
                    where (dependOn.StartDate is null || dependOn.CompleteDate > date)
                    select dependOn.CompleteDate;

            if (t.Any())
                throw new Exception($"The last start date of depend task is {t.Max()}\n");

            dtask = dtask with
            {
                StartDate = date
            };

            dal.Task.Update(dtask);
        }
        catch { }
    }

    public void ScheduleTasks(DateTime startDate)
    {
        try
        {
            Dictionary<int, DO.Task> tasks = dal.Task.ReadAll().ToList().ToDictionary(task => task.Id);
            List<Dependency> dependencies = dal.Dependency.ReadAll().ToList();


            // Initialize the schedule with tasks that have no dependencies
            Dictionary<int, DO.Task> schedule = tasks.Where(task => !dependencies.Any(dep => dep.DependentTask == task.Key)).
                Select(task => task.Value).ToList().ToDictionary(task => task.Id);

            foreach (int key in schedule.Keys)
            {
                DO.Task old = schedule[key];
                TimeSpan? lenghTask = old.RequiredEffortTime;
                old = old with { ScheduledDate = startDate, DeadlineDate = startDate + lenghTask };
                schedule[key] = old;
                tasks.Remove(key);
            }

            while (tasks.Count > 0)
            {
                foreach (int newTask in tasks.Keys)
                {
                    bool canSchedule = true;

                    foreach (Dependency dep in dependencies.Where(dep => dep.DependentTask == newTask))
                    {
                        if (!schedule.ContainsKey(dep.DependsOnTask))
                        {
                            canSchedule = false;
                            break;
                        }
                    }

                    if (canSchedule)
                    {
                        DateTime? earlyStart = DateTime.MinValue;
                        DateTime? lastDepDate = DateTime.MinValue;

                        foreach (Dependency dep in dependencies.Where(dep => dep.DependentTask == newTask))
                        {
                            lastDepDate = schedule[dep.DependsOnTask].DeadlineDate;
                            if (lastDepDate > earlyStart)
                                earlyStart = lastDepDate;
                        }
                        tasks[newTask] = tasks[newTask] with { ScheduledDate = earlyStart, DeadlineDate = earlyStart + tasks[newTask].RequiredEffortTime };

                        schedule.Add(newTask, tasks[newTask]);
                        tasks.Remove(newTask);
                    }
                }
            }

            schedule.Values.ToList().ForEach(task => { dal.Task.Update(task); });
            dal.StartDate = startDate;
            dal.EndDate = schedule.Values.Max(t => t.DeadlineDate);
        }
        catch { }
    }

    public IEnumerable<BO.TaskInGantt> GanttList()
    {
        return (from task in dal.Task.ReadAll()
                select new BO.TaskInGantt()
                {
                    Id = task.Id,
                    Name = task.Alias!,
                    StartOffset = (int)(task.ScheduledDate - dal.StartDate)!.Value.TotalHours,
                    TaskLenght = (int)task.RequiredEffortTime!.Value.TotalHours,
                    Status = Tools.GetStatus(task),
                    CompliteValue = CalcValue(task),
                    Dependencies = StringDependencies(task.Id)
                }).ToList().OrderBy(t => t.StartOffset).ThenBy(t=>t.TaskLenght);
    }

    public IEnumerable<TaskInList> EngineerTasks(int id, bool allMyTasks)
    {
        if (allMyTasks)
        {
            return from task in dal.Task.ReadAll()
                   where task.EngineerId == id
                   select new TaskInList()
                   {
                       Id = task.Id,
                       Level = (BO.Level)task.Copmlexity,
                       Alias = task.Alias,
                       Status = Tools.GetStatus(task)
                   };
        }
        DO.Level experience = dal.Engineer.Read(id).Level;
        return from task in dal.Task.ReadAll()
               where task.Copmlexity <= experience && task.EngineerId == 0
               select new TaskInList()
               {
                   Id = task.Id,
                   Level = (BO.Level)task.Copmlexity,
                   Alias = task.Alias,
                   Status = Tools.GetStatus(task)
               };
    }

    /************ Tools Functoin ***************/
    private int CalcValue(DO.Task task)
    {
        if (task.StartDate is null)
            return 0;

        DateTime clock = dal.Clock;
        if (clock > task.StartDate && task.CompleteDate is null)
            return (int)((double)(clock - task.StartDate).Value.TotalHours / (double)task.RequiredEffortTime!.Value.TotalHours);

        return 0;
    }

    private bool IsValid(Task task)
    {
        return string.IsNullOrEmpty(task.Description) ? false :
        task.Id < 1 ? false : true;
    }

    private string StringDependencies(int id)
    {
        var x = dal.Dependency.ReadAll(x => x.DependentTask == id)
                                    .Where(dependency => dependency.DependentTask == id)
                                    .Select(dependency => dependency.DependsOnTask.ToString() + " ");
        string dep = "";
        foreach (string tmp in x)
        {
            dep += tmp.ToString();
        }
        return dep;
    }

}
