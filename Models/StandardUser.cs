namespace JsonNugetAssignment.Models;

public class StandardUser : User
{
    public StandardUser()
    {
        Type = "user";
    }

    public string SubscriptionPlan { get; set; } = string.Empty;
    public int LoyaltyPoints { get; set; }

    public override string ToConsoleLine()
    {
        return $"{base.ToConsoleLine()}, Plan: {SubscriptionPlan}, Loyalty points: {LoyaltyPoints}";
    }
}
