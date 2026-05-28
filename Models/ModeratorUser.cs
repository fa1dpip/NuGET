namespace JsonNugetAssignment.Models;

public class ModeratorUser : User
{
    public ModeratorUser()
    {
        Type = "moderator";
    }

    public string Section { get; set; } = string.Empty;
    public int ReportsHandled { get; set; }

    public override string ToConsoleLine()
    {
        return $"{base.ToConsoleLine()}, Section: {Section}, Reports handled: {ReportsHandled}";
    }
}
