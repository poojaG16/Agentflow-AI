namespace AgentService.Models;

public class InstalledAgent
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid AgentId { get; set; }

    public DateTime InstalledAt { get; set; } = DateTime.UtcNow;
}