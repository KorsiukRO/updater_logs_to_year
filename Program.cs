using System.Xml;
using Cocona;

CoconaApp.Run((string days) =>
{
    try
    {
        UpdateLogsToYear(days);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
});
return;

void UpdateLogsToYear(string days)
{
    const string filePath = "C:/prosafe/scheduler/tasks.config";

    if (!File.Exists(filePath)) //перевірка наявності файлу конфігурації
    {
        Console.WriteLine($"\nERROR: {filePath} not found!");
        return;
    }

    // Завантаження XML-документа
    var xmlDoc = new XmlDocument();
    xmlDoc.Load(filePath);

    // Знайдення елементу <maxArchiveFiles>
    var maxArchiveFilesNode = xmlDoc.SelectSingleNode("//maxArchiveFiles");
    if (maxArchiveFilesNode is null)
    {
        Console.WriteLine("\n<maxArchiveFiles> not found!");
        return;
    }

    // Зміна значення елементу <maxArchiveFiles>
    maxArchiveFilesNode.InnerText = days;

    // Збереження змін у файл
    xmlDoc.Save(filePath);
    Console.WriteLine($"The value of <maxArchiveFiles> was successfully changed to {days}.");
}