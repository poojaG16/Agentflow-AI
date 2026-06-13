namespace Shared.Contracts.Workflows;

public class WorkflowStepDto
{
    public Guid AgentId { get; set; }

    public int StepOrder { get; set; }
}