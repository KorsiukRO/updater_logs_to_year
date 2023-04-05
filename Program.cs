using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

var location = new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath;
var path = Path.GetDirectoryName(location);
//var filePath = Path.GetFullPath(Convert.ToString((args[0])));
var filePath = Path.GetFullPath(Convert.ToString("C:/prosafe/scheduler/tasks.config"));

if (!File.Exists(filePath))
{
    throw new InvalidOperationException("\nERROR: C:/prosafe/sheduler/tasks.config not found!");
}

var document = XDocument.Load(filePath);

var rootcourse = document.XPathSelectElement("tasks/task[@name='LogArchiverSchedulerTask'][@type='log']/customconfig/maxArchiveFiles");
//var gieseckeEnabledElement = document.XPathSelectElement("tasks/task[@name='LogArchiverSchedulerTask'][@type='log']/customconfig/maxArchiveFiles");
//if (gieseckeEnabledElement?.Value != Convert.ToString(365))
//{
//    gieseckeEnabledElement.Value = Convert.ToString(365);
//    document.Save(filePath);
//}

Console.WriteLine(document);