using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlApi;
using BO;
namespace BlImplementation;


internal class TaskImplementation : ITask
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public IEnumerable<BO.TaskInList> ReadAll(Func<TaskInList, bool> filter = null)
    {
        return (from DO.Task doTask in _dal.Task.ReadAll()
                select new BO.TaskInList
                {
                    Id = doTask.Id,
                    Alias = doTask.Alias,
                    Level = (BO.Level)doTask.Hardness,
                    Status = GetStatus(doTask)
                }).Where(task => filter is null ? true : filter(task));
    }
    public int Create(BO.Task boTask)
    {
        DO.Task doTask = new DO.Task()
        {
            Id = boTask.Id,
            Alias = boTask.Alias,
            Description = boTask.Description,
            CreatedAtDate = boTask.CreatedAtDate,
            RequiredEffortTime = boTask.RequiredEffortTime,
            StartDate = boTask.StartDate,
            //  boTask.DeadlineDate,
            ScheduleDate = boTask.ScheduleDate,
            Deliverables = boTask.Deliverables,
            EngineerId = boTask.EngineerId,
            Hardness = (DO.Level)boTask.Complexity
        };

        try
        {
            int idEng = _dal.Task.Create(doTask);
            return idEng;
        }
        catch (DO.DalAlreadyExistsException ex)
        {
            throw new BO.BlAlreadyExistsException($"Task with ID={boTask.Id} already exists", ex);
        }
    }
    public BO.Task? Read(int Id)
    {
        DO.Task? doTask = _dal.Task.Read(Id);
        if (doTask == null)
            throw new BO.BlDoesNotExistException($"Task with ID={Id} does Not exist");
        return new BO.Task()
        {
            Id = doTask.Id,
            Alias = doTask.Alias ?? string.Empty,
            Description = doTask.Description ?? string.Empty,
            CreatedAtDate = doTask.CreatedAtDate,
            RequiredEffortTime = doTask.RequiredEffortTime,
            StartDate = doTask.StartDate,
            ScheduleDate = doTask.ScheduleDate,
            Deliverables = doTask.Deliverables,
            EngineerId = doTask.EngineerId,
            Complexity = (BO.Level)doTask.Hardness,
            Status = GetStatus(doTask)
        };

    }

    public void Update(BO.Task boTask)
    {
        DO.Task doTask = new DO.Task
        (boTask.Id, boTask.Alias, boTask.Description, boTask.CreatedAtDate, boTask.RequiredEffortTime, boTask.IsMilestone, boTask.StartDate, boTask.DeadlineDate, boTask.CreatedAtDate, boTask.Deliverables, boTask.EngineerId, (DO.Level)boTask.Complexity);
        try
        {
            _dal.Task.Update(doTask);
            return;
        }
        catch (DO.DalAlreadyExistsException ex)
        {
            throw new BO.BlAlreadyExistsException($"Task with ID={boTask.Id} already exists", ex);
        }
    }

    public void Delete(int id)
    {
        try
        {
            _dal.Task.Delete(id);
            return;
        }
        catch (DO.DalDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException($"Task with ID={id} already exists", ex);
        }
    }

    private Status GetStatus(DO.Task task)
    {
        return task.ScheduleDate is null ? Status.Unscheduled :
            task.StartDate is null ? Status.Scheduled :
            task.CompleteDate is null ? Status.OnTrack : Status.Done;
    }
}

