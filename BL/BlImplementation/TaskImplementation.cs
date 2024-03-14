using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlApi;
using BO;
using DalApi;
using DO;
namespace BlImplementation
{
   

    internal class TaskImplementation :ITask
    {




        private DalApi.IDal _dal = DalApi.Factory.Get;
        public IEnumerable<BO.Task> ReadAll() { }
        public int Create(BO.Task task)
        {
            return (from DO.Task doTask in _dal.Task.ReadAll()
                    select new BO.Task
                    {
           


                        Id = doTask.Id,
                        Alias = doTask.Alias,
                        CreatedAtDate = doTask.CreatedAtDate,
                        RequiredEffortTime = doTask.RequiredEffortTime,
                        Copmlexity = (BO.Level)doTask.Copmlexity,
                             StartDate = doTask.StartDate,
                              ScheduledDate = doTask.ScheduledDate
                    });
        }
        public BO.Task? Read(int Id)
        {
            DO.Task? doTask = _dal.Task.Read(id);
            if (doTask == null)
                throw new BO.BlNotExistException($"Task with ID={id} does Not exist");
            return new BO.Task()
            {
                Id = doTask.Id,
                Email = doTask.Email,
                Cost = doTask.Cost,
                Name = doTask.Name,
                level = (BO.Level)doTask.Level
            }
        public void Update(BO.Task item) { }
        public void Delete(int id) { }
    }
}
