using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation;
using BlApi;
using BO;

internal class EngineerImplementation : IEngineer
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Engineer boEngineer)
    {
        DO.Engineer doEngineer = new DO.Engineer
        (boEngineer.Id, boEngineer.Name, boEngineer.Email, (DO.Level)boEngineer.level, boEngineer.Cost);
        try
        {
            int idEng = _dal.Engineer.Create(doEngineer);
            return idEng;
        }
        catch (DO.DalAlreadyExistsException ex)
        {
            throw new BO.BlAlreadyExistsException($"Engineer with ID={boEngineer.Id} already exists", ex);
        }
    }

    public IEnumerable<Engineer> ReadAll(Func<Engineer, bool> filter = null)
    {
        return (from DO.Engineer doEngineer in _dal.Engineer.ReadAll()
                select new BO.Engineer
                {
                    Id = doEngineer.Id,
                    Name = doEngineer.Name,
                    Email = doEngineer.Email,
                    Cost = doEngineer.Cost,
                    level = (BO.Level)doEngineer.Level
                }).Where(engineer => filter is null ? true : filter(engineer));
    }

    public void Delete(int id)
    {
        try
        {
            _dal.Engineer.Delete(id);
            return;
        }
        catch (DO.DalDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException($"Engineer with ID={id} already exists", ex);
        }
    }

    public BO.Engineer? Read(int id)
    {
        DO.Engineer? doEngineer = _dal.Engineer.Read(id);
        if (doEngineer == null)
            throw new BO.BlDoesNotExistException($"Engineer with ID={id} does Not exist");
        return new BO.Engineer()
        {
            Id = doEngineer.Id,
            Email = doEngineer.Email,
            Name = doEngineer.Name,
            level = (BO.Level)doEngineer.Level,
            Cost = doEngineer.Cost
        };
    }

    public IEnumerable<BO.Engineer> ReadAll()
    {
        return from DO.Engineer doEngineer in _dal.Engineer.ReadAll()
               select new BO.Engineer()
               {
                   Id = doEngineer.Id,
                   Email = doEngineer.Email,
                   Name = doEngineer.Name,
                   level = (BO.Level)doEngineer.Level,
                   Cost = doEngineer.Cost
               };
    }

    public void Update(BO.Engineer boEngineer)
    {
        DO.Engineer doEngineer = new DO.Engineer
               (boEngineer.Id, boEngineer.Name, boEngineer.Email, (DO.Level)boEngineer.level, boEngineer.Cost);
        try
        {
            _dal.Engineer.Update(doEngineer);
            return;
        }
        catch (DO.DalAlreadyExistsException ex)
        {
            throw new BO.BlAlreadyExistsException($"Engineer with ID={boEngineer.Id} already exists", ex);
        }
    }
}
