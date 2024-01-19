namespace Dal;

using DalApi;
using DO;
using System;
using System.Xml.Linq;


internal class DependencyImplementation : IDependency
{
    readonly string s_dependencies_xml = "dependencies";
    public int Create(Dependency item)
    {
        XElement xml = XMLTools.LoadListFromXMLElement(s_dependencies_xml);
        int idNum = Config.NextDependencyId;
        xml.Add(item with { Id = idNum });
        XMLTools.SaveListToXMLElement(xml, s_dependencies_xml);
        return idNum;
    }
    public void Delete(int id)
    {
        XElement xml = XMLTools.LoadListFromXMLElement(s_dependencies_xml);

        XElement? dep = (from d in xml.Elements()
                         where Convert.ToInt32(d.Element("Id")) == id
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
        XElement? dep = (from d in xml.Elements()
                         where Convert.ToInt32(GetDependency(d.Element("Id"))) == id
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
            list = from dep in xml.Elements()
                   select GetDependency(dep);
        }
        else
        {
            list = from dep in xml.Elements()
                   where filter(GetDependency(dep))
                   select GetDependency(dep);
        }
        return list;
    }
    public void Update(Dependency item)
    {
        XElement xml = XMLTools.LoadListFromXMLElement(s_dependencies_xml);
        XElement? dep = (from d in xml.Elements()
                         where GetDependency(d) == item
                         select d).FirstOrDefault();
        if (dep == null)
        {
            throw new DalDoesNotExistException($"Dependency with ID {item.Id} does not exist.");
        }
        else
        {
            int id = Convert.ToInt32(dep.Element("Id"));
            dep.Remove();
            xml.Add(item);
        }
        XMLTools.SaveListToXMLElement(xml, s_dependencies_xml);
    }
    internal Dependency? GetDependency(XElement? item)
    {
        if (item == null)
            return null;
        else
        {
            int Id = Convert.ToInt32(item.Element("DependentTask"));
            int DependentTask = Convert.ToInt32(item.Element("DependentTask"));
            int DependsOnTask = Convert.ToInt32(item.Element("DependsOnTask"));
            Dependency dependency = new Dependency(Id, DependentTask, DependsOnTask);
            return dependency;
        }
    }
}