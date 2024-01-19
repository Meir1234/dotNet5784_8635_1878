
namespace Dal;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Net;

internal class TaskImplementation : ITask
{
    public int Create(Task item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task? Read(int id)
    {
        throw new NotImplementedException();
    }

    public Task? Read(Func<Task?, bool> filter)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Task?> ReadAll(Func<Task?, bool>? filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(Task item)
    {
        throw new NotImplementedException();
    }
}
//{
//    readonly string s_tasks_xml = "tasks";
//    public int Create(Task item)
//    {
//        List<Task> Tasks = XMLTools.LoadListFromXMLElement<Task>(s_tasks_xml);
//        int nextId = Config.NextTaskId;
//        Task copy= item with(IDal = nextId);
//        Task.Add(copy);
//        XMLTools.SaveListToXMLElement(Tasks, s_tasks_xml);
//    }


//    public void Delete(int id)
//    {

//    }

//    public Task? Read(int id)
//    {

//    }

//    public Task? Read(Func<Task, bool> filter)
//    {

//    }

//    public IEnumerable<Task?> ReadAll(Func<Task, bool>? filter = null)
//    {

//    }

//    public void Update(Task item)
//    {
//        List<Task> Tasks = XMLTools.LoadListFromXMLElement<Task>(s_tasks_xml);
//        {
//            {
//                int updatedObjectId = item.Id;
//                bool found = false;

//                foreach (Task? obj in DataSource.Tasks)
//                {
//                    if (obj.Id == updatedObjectId)
//                    {
//                        DataSource.Tasks.Remove(obj);
//                        DataSource.Tasks.Add(item);
//                        found = true;
//                        break;
//                    }
//                }

//                if (!found)
//                {
//                    throw new ArgumentException($"Task with ID {updatedObjectId} does not exist.");
//                }
//            }

//        }
//    }
