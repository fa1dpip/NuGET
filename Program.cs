using JsonNugetAssignment.Models;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace JsonNugetAssignment;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Task 1 - Manual JSON file");
        User singleUser = ReadSingleJsonUser("user.json");
        Console.WriteLine(singleUser.ToConsoleLine());

        Console.WriteLine();
        Console.WriteLine("Task 1 - XML reader example");
        foreach (User user in ReadUsersFromXml("users.xml"))
        {
            Console.WriteLine(user.ToConsoleLine());
        }
    }

    private static User ReadSingleJsonUser(string fileName)
    {
        string json = File.ReadAllText(GetDataPath(fileName));

        // This follows the theory example: JSON text is deserialized into a C# object.
        return JsonConvert.DeserializeObject<User>(json) ?? new User();
    }

    private static List<User> ReadUsersFromXml(string fileName)
    {
        XDocument document = XDocument.Load(GetDataPath(fileName));
        List<User> users = new();

        foreach (XElement element in document.Root?.Elements("user") ?? Enumerable.Empty<XElement>())
        {
            users.Add(new User
            {
                Name = element.Element("name")?.Value ?? string.Empty,
                Age = int.TryParse(element.Element("age")?.Value, out int age) ? age : 0,
                City = element.Element("city")?.Value ?? string.Empty
            });
        }

        return users;
    }

    private static string GetDataPath(string fileName)
    {
        return Path.Combine(AppContext.BaseDirectory, "Data", fileName);
    }
}
