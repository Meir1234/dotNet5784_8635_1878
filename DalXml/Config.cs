using System.Globalization;
using System.Xml.Linq;

namespace Dal;
internal static class Config
{
    static string directory = @"..\xml\";

    static string s_data_config_xml = "data-config";
    internal static int NextTaskId { get => XMLTools.GetAndIncreaseNextId(s_data_config_xml, "NextTaskId"); }
    internal static int NextDependencyId { get => XMLTools.GetAndIncreaseNextId(s_data_config_xml, "NextDependecyId"); }

    internal static DateTime? GetDate(string elementName)
    {
        XElement root = XElement.Load(directory + s_data_config_xml + ".xml");
        string dateStr = root.Element(elementName)!.Value;

        if (string.IsNullOrEmpty(dateStr))
            return null;
        DateTime date = DateTime.ParseExact(dateStr, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        return date;
    }

    internal static void SetDate(string elementName, DateTime? date)
    {
        XElement root = XElement.Load(directory + s_data_config_xml + ".xml");
        root.Element(elementName)!.ReplaceWith(new XElement(elementName, date.ToString()));
        root.Save(directory + s_data_config_xml+ ".xml");
    }
}
