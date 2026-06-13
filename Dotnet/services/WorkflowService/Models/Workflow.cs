namespace WorkflowService.Models
{
    public class Workflow

    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Guid UserId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}