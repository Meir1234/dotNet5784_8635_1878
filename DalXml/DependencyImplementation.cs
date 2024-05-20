namespace Dal;

using DalApi;
using DO;
using System;
using System.Xml.Linq;


internal class DependencyImplementation : IDependency
{
    readonly string s_dependencies_xml = "dependencies";
    readonly string s_config_xml = "data-config";

    public void Clear()
    {
        XElement xml = XMLTools.LoadListFromXMLElement(s_dependencies_xml);
        XElement config = XMLTools.LoadListFromXMLElement(s_config_xml);

        xml.RemoveAll();
        config.Element("NextDependecyId").SetValue(1);

        XMLTools.SaveListToXMLElement(xml, s_dependencies_xml);
        XMLTools.SaveListToXMLElement(config, s_config_xml);
    }

    public int Create(Dependency item)
    {
        XElement xml = XMLTools.LoadListFromXMLElement(s_dependencies_xml);
        int idNum = Config.NextDependencyId;
        
        XElement id = new XElement("Id", idNum);
        XElement dep = new XElement("DependentTask", item.DependentTask);
        XElement depOn = new XElement("DependsOnTask", item.DependsOnTask);
        xml.Add(new XElement("Dependency",id,dep,depOn));
        XMLTools.SaveListToXMLElement(xml, s_dependencies_xml);
        return idNum;
    }
    public void Delete(int id)
    {
        XElement xml = XMLTools.LoadListFromXMLElement(s_dependencies_xml);

        XElement? dep = (from d in xml.Elements("Dependency")
                         where Convert.ToInt32(d.Element("Id").Value) == id
                         select d).FirstOrDefault();
        if (dep == null)
        {
            throw new DalDoesNotExistException($"Dependency with ID {id} does not exist.");
        }
        else
        {
            dep.Remove();
        }

        XMLTools.SaveListToXMLElement(xml, s_dependencies_xml);
    }
    public Dependency? Read(int id)
    {
        XElement? xml = XMLTools.LoadListFromXMLElement(s_dependencies_xml);
        XElement? dep = (from d in xml.Elements("Dependency")
                         where Convert.ToInt32(d.Element("Id").Value) == id
                         select d).FirstOrDefault();
        if (dep == null)
            throw new DalDoesNotExistException($"Dependency with ID {id} does not exist.");
        else
        {
            //XElement? foundDependency = xml.Elements().FirstOrDefault(dependency => (int?)dependency.Element("Id") == id);
            Dependency? dependency = GetDependency(dep);
            return dependency;
        }
    }
    public Dependency? Read(Func<Dependency?, bool> filter)
    {

        XElement? xml = XMLTools.LoadListFromXMLElement(s_dependencies_xml);
        XElement? foundDependency;

        foundDependency = (from dep in xml.Elements()
                           where filter(GetDependency(dep))
                           select dep).FirstOrDefault();

        Dependency? dependency = GetDependency(foundDependency);
        return dependency;
    }
    public IEnumerable<Dependency?> ReadAll(Func<Dependency?, bool>? filter)
    {
        XElement? xml = XMLTools.LoadListFromXMLElement(s_dependencies_xml);
        IEnumerable<Dependency?> list;
        if (filter == null)
        {
            list = (from dep in xml.Elements("Dependency")
                   select GetDependency(dep)).ToList();
        }
        else
        {
            list = (from dep in xml.Elements()
                   where filter(GetDependency(dep))
                   select GetDependency(dep)).ToList();
        }
        return list;
    }
    public void Update(Dependency item)
    {
        XElement xml = XMLTools.LoadListFromXMLElement(s_dependencies_xml);

        XElement? temp = (from d in xml.Elements("Dependency")
                         where Convert.ToInt32(d.Element("Id").Value) == item.Id
                         select d).FirstOrDefault();

        //XElement? depn = (from d in xml.Elements("Dependency")
        //                 let idElement = d.Element("Id")
        //                 where idElement != null && int.TryParse(idElement.Value, out int id) && id == item.Id
        //                 select d).FirstOrDefault();

        if (temp == null)
        {
            throw new DalDoesNotExistException($"Dependency with ID {item.Id} does not exist.");
        }
        else
        {
            temp.Remove();
            XElement id = new XElement("Id", item.Id);
            XElement dep = new XElement("DependentTask", item.DependentTask);
            XElement depOn = new XElement("DependsOnTask", item.DependsOnTask);
            xml.Add(new XElement("Dependency", id, dep, depOn));
        }
        XMLTools.SaveListToXMLElement(xml, s_dependencies_xml);
    }
    internal Dependency? GetDependency(XElement? item)
    {
        if (item == null)
            return null;
        else
        {
            int Id = Convert.ToInt32(item.Element("Id").Value);
            int DependentTask = Convert.ToInt32(item.Element("DependentTask").Value);
            int DependsOnTask = Convert.ToInt32(item.Element("DependsOnTask").Value);
            Dependency dependency = new Dependency(Id, DependentTask, DependsOnTask);
            return dependency;
        }
    }
}