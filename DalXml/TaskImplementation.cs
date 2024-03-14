
namespace Dal;
using DalApi;
using DO;
using System.Xml.Linq;

//using System;
//using System.Data.Common;

//using System;
//using System.Net;

internal class TaskImplementation : ITask
{
    readonly string s_tasks_xml = "tasks";
    readonly string s_config_xml = "data-config";

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
        Task? foundTask = tasks.FirstOrDefault(filter);
        XMLTools.SaveListToXMLSerializer(tasks, s_tasks_xml);
        return foundTask;
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
        }
        XMLTools.SaveListToXMLSerializer(Tasks, s_tasks_xml);
    }

    public void Clear()
    {
        XElement xml = XMLTools.LoadListFromXMLElement(s_tasks_xml);
        XElement config = XMLTools.LoadListFromXMLElement(s_config_xml);

        xml.RemoveAll();
        config.Element("NextTaskId").SetValue(1);

        XMLTools.SaveListToXMLElement(xml, s_tasks_xml);
        XMLTools.SaveListToXMLElement(config, s_config_xml);
    }
}
