using System.Xml;
using Cocona;

CoconaApp.Run(async (string days) =>
    await MigrateHdServiceConfigAsync(days)
);

async Task MigrateHdServiceConfigAsync(string days)
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
        maxArchiveFilesNode.InnerText = days;

        // Збереження змін у файл
        xmlDoc.Save(filePath);
        Console.WriteLine($"The value of <maxArchiveFiles> was successfully changed to {days}.");
    }
    else
    {
        throw new InvalidOperationException("\n<maxArchiveFiles> not found!");
    }
}
     