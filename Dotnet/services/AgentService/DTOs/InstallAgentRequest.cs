using System;

namespace AgentService.DTOs;

public class InstallAgentRequest
{
    public Guid AgentId { get; set; }
    public Guid UserId { get; set; }
}
