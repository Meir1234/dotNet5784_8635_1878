
namespace Dal;
using DalApi;
using DO;
//using System;
//using System.Data.Common;

//using System;
//using System.Net;

internal class TaskImplementation : ITask
{
    public int Create(Task item)
    {
        List<Task> tasks = XMLTools.LoadListFromXMLSerializer<Task>(s_tasks_xml);
        int nextId = Config.NextTaskId;
        tasks.Add(item with { Id = nextId });
        XMLTools.SaveListToXMLSerializer(tasks, s_tasks_xml);
        return nextId;
    }




    public void Delete(int id)
    {
        List<Task> Tasks = XMLTools.LoadListFromXMLSerializer<Task>(s_tasks_xml);
        if (!Tasks.Any(task => task.Id == id))
            throw new DalDoesNotExistException($"Task with ID={id} does not exist");
        Tasks.RemoveAll(task => task.Id == id);
        XMLTools.SaveListToXMLSerializer(Tasks, s_tasks_xml);
    }

    public Task? Read(int id)
    {
        List<Task> tasks = XMLTools.LoadListFromXMLSerializer<Task>(s_tasks_xml);
        Task? foundTask = tasks.FirstOrDefault(task => task.Id == id);
        
        XMLTools.SaveListToXMLSerializer(tasks, s_tasks_xml);
        return foundTask;
    }

    public Task? Read(Func<Task?, bool> filter)
    {
        List<Task> tasks = XMLTools.LoadListFromXMLSerializer<Task>(s_tasks_xml);
        tasks.FirstOrDefault(filter);
        XMLTools.SaveListToXMLSerializer(tasks, s_tasks_xml);
        return tasks;
    }

    public IEnumerable<Task?> ReadAll(Func<Task?, bool>? filter = null)
    {
        List<Task> tasks = XMLTools.LoadListFromXMLSerializer<Task>(s_tasks_xml);
        if (filter == null) 
            tasks.Select(item => item);
        else
            tasks.Where(filter);
        XMLTools.SaveListToXMLSerializer(tasks, s_tasks_xml);
        return tasks;
    }

    public void Update(Task item)
    {
        List<Task> Tasks = XMLTools.LoadListFromXMLSerializer<Task>(s_tasks_xml);
        {
            {
                int updatedObjectId = item.Id;
                bool found = false;

                foreach (Task? obj in Tasks)
                {
                    if (obj.Id == updatedObjectId)
                    {
                        Tasks.Remove(obj);
                        Tasks.Add(item);
                        found = true;
                        break;
                    }
                }

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

        }
        XMLTools.SaveListToXMLSerializer(Tasks, s_tasks_xml);
    }
}
