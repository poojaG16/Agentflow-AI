namespace Shared.Contracts.Agents;

public class InstallAgentRequest
{
    public Guid AgentId { get; set; }

    public Guid UserId { get; set; }
}