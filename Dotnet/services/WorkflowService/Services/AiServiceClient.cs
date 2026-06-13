using System.Net.Http.Json;

namespace WorkflowService.Services;

public class AgentClient
{
    private readonly HttpClient _httpClient;

    public AgentClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AgentDto?> GetAgent(Guid agentId)
    {
        return await _httpClient.GetFromJsonAsync<AgentDto>(
            $"api/agent/{agentId}");
    }
}