namespace Shared.Contracts.Agents;

public class AgentDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Endpoint { get; set; } = string.Empty;

    public string Method { get; set; } = "POST";

    public string InputSchema { get; set; } = string.Empty;

    public string OutputSchema { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}