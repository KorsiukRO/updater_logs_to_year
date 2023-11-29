using System.Reflection;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        var filePath = "C:/prosafe/scheduler/tasks.config";

        if (!File.Exists(filePath)) //перевірка наявності файлу конфігурації
        {
            throw new InvalidOperationException($"\nERROR: {filePath} not found!");
        }

        // Завантаження XML-документа
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(filePath);

        // Знайдення елементу <maxArchiveFiles>
        XmlNode maxArchiveFilesNode = xmlDoc.SelectSingleNode("//maxArchiveFiles");

        if (maxArchiveFilesNode != null)
        {
            // Зміна значення елементу <maxArchiveFiles>
            maxArchiveFilesNode.InnerText = args[1];

            // Збереження змін у файл
            xmlDoc.Save(filePath);
            Console.WriteLine($"Значення <maxArchiveFiles> успiшно змiнено на {args[1]}.");
        }
        else
        {
            throw new InvalidOperationException("\n<maxArchiveFiles> not found!"); 
        }
    }
}