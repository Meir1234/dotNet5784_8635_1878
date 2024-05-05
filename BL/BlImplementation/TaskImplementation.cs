using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlApi;
using BO;
namespace BlImplementation;


internal class TaskImlementation : ITask
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public IEnumerable<BO.Task> ReadAll()
    {

        return from DO.Task doTask in _dal.Task.ReadAll()
               select new BO.Task
                        (doTask.Id,
            doTask.Alias ?? string.Empty,
            doTask.Description ?? string.Empty,
            doTask.CreatedAtDate,
            doTask.RequiredEffortTime,
            doTask.IsMilestone,
            doTask.StartDate,
            doTask.DeadlineDate,
            doTask.Deliverables,
            doTask.EngineerId,
            (BO.Level)doTask.Hardness);

    }
    public int Create(BO.Task boTask)
    {
        DO.Task doTask = new DO.Task
        (boTask.Id, boTask.Alias, boTask.Description, boTask.CreatedAtDate, boTask.RequiredEffortTime, boTask.IsMilestone, boTask.StartDate, boTask.DeadlineDate, boTask.CreatedAtDate, boTask.Deliverables, boTask.EngineerId, (DO.Level)boTask.Complexity);
        
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
        return new BO.Task
            (doTask.Id,
            doTask.Alias ?? string.Empty,
            doTask.Description ?? string.Empty,
            doTask.CreatedAtDate,
            doTask.RequiredEffortTime,
            doTask.IsMilestone,
            doTask.StartDate,
            doTask.DeadlineDate,
            doTask.Deliverables,
            doTask.EngineerId,
            (BO.Level)doTask.Hardness);
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
}

