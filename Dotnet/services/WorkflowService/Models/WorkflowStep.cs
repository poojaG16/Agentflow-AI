namespace WorkflowService.Models
{
    public class WorkflowStep
    {
        public Guid Id { get; set; }

        public Guid WorkflowId { get; set; }

        public Guid AgentId { get; set; }

        public int StepOrder { get; set; }
    }
}