namespace JsonNugetAssignment.Models;

public class AdminUser : User
{
    public AdminUser()
    {
        Type = "admin";
    }

    public bool CanManageUsers { get; set; }
    public List<string> Permissions { get; set; } = new();

    public override string ToConsoleLine()
    {
        return $"{base.ToConsoleLine()}, Can manage users: {CanManageUsers}, Permissions: {string.Join(", ", Permissions)}";
    }
}
