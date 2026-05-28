using JsonNugetAssignment.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        Console.WriteLine();
        Console.WriteLine("Task 2 - JSON object with several user entries");
        List<User> users = ReadUsersFromJson("users.json");

        // The loop is required because the JSON file now contains several entries.
        foreach (User user in users)
        {
            Console.WriteLine(user.ToConsoleLine());
        }

        Console.WriteLine();
        Console.WriteLine("Task 3 - Inheritance and specialized user types");
        List<User> typedUsers = ReadUsersByTypeFromJson("user-types.json");

        foreach (User user in typedUsers)
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

    private static List<User> ReadUsersFromJson(string fileName)
    {
        string json = File.ReadAllText(GetDataPath(fileName));
        UserCollection collection = JsonConvert.DeserializeObject<UserCollection>(json) ?? new UserCollection();

        return collection.Users;
    }

    private static List<User> ReadUsersByTypeFromJson(string fileName)
    {
        string json = File.ReadAllText(GetDataPath(fileName));
        JObject root = JObject.Parse(json);
        List<User> users = new();

        // Each JSON entry is inspected, then deserialized into the matching inherited class.
        foreach (JToken token in root["Users"] ?? new JArray())
        {
            string type = token.Value<string>("Type")?.ToLowerInvariant() ?? "user";
            User user = type switch
            {
                "admin" => token.ToObject<AdminUser>() ?? new AdminUser(),
                "moderator" => token.ToObject<ModeratorUser>() ?? new ModeratorUser(),
                _ => token.ToObject<StandardUser>() ?? new StandardUser()
            };

            users.Add(user);
        }

        return users;
    }

    private static string GetDataPath(string fileName)
    {
        return Path.Combine(AppContext.BaseDirectory, "Data", fileName);
    }
}
