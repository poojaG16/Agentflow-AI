using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AgentService.Services;
using AgentService.Models;
using AgentService.DTOs;

namespace AgentService
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly AgentsService _service;

        public AgentController(AgentsService service)
        {
            _service = service;
        }

        [HttpGet("marketplace")]
        public async Task<IActionResult> GetMarketplace()
        {
            var agents = await _service.GetMarketplaceAgents();
            return Ok(agents);
        }

        [HttpPost("install")]
        public async Task<IActionResult> Install(InstallAgentRequest request)
        {
            await _service.InstallAgent(request);
            return Ok("Agent installed successfully");
        }

        [HttpGet("my/{userId}")]
        public async Task<IActionResult> GetMyAgents(Guid userId)
        {
            var agents = await _service.GetInstalledAgents(userId);
            return Ok(agents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgent(Guid id)
        {
            var agent = await _service.GetAgentById(id);
            if (agent == null) return NotFound();

            return Ok(agent);
        }
    }
}
