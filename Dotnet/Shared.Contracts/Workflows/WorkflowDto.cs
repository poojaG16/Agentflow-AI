namespace Shared.Contracts.Workflows;

public class WorkflowDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public List<WorkflowStepDto> Steps { get; set; } = [];
}