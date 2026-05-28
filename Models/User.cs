namespace JsonNugetAssignment.Models;

public class User
{
    public string Type { get; set; } = "user";
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string City { get; set; } = string.Empty;

    public virtual string ToConsoleLine()
    {
        return $"Type: {Type}, Name: {Name}, Age: {Age}, City: {City}";
    }
}
