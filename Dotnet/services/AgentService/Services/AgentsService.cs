using AgentService.Data;
using AgentService.Models;
using AgentService.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AgentService.Services;

public class AgentsService
{
    private readonly AgentDbContext _context;

    public AgentsService(AgentDbContext context)
    {
        _context = context;
    }

    public async Task<List<AgentResponse>> GetMarketplaceAgents()
    {
        return await _context.Agents
            .Where(a => a.IsActive)
            .Select(a => new AgentResponse
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description
            })
            .ToListAsync();
    }

    public async Task InstallAgent(InstallAgentRequest request)
    {
        var exists = await _context.InstalledAgents
            .AnyAsync(x => x.AgentId == request.AgentId && x.UserId == request.UserId);

        if (exists)
            throw new Exception("Agent already installed");

        var installed = new Models.InstalledAgent
        {
            AgentId = request.AgentId,
            UserId = request.UserId
        };

        _context.InstalledAgents.Add(installed);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Agent>> GetInstalledAgents(Guid userId)
    {
        var agentIds = await _context.InstalledAgents
            .Where(x => x.UserId == userId)
            .Select(x => x.AgentId)
            .ToListAsync();

        return await _context.Agents
            .Where(a => agentIds.Contains(a.Id))
            .ToListAsync();
    }

    public async Task<Agent?> GetAgentById(Guid id)
    {
        return await _context.Agents.FirstOrDefaultAsync(a => a.Id == id);
    }
}