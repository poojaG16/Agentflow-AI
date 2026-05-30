using System;
using AgentService.Models;
using Microsoft.EntityFrameworkCore;

namespace AgentService.Data;

public class AgentDbContext : DbContext
{
    public AgentDbContext(DbContextOptions<AgentDbContext> options)
        : base(options) { }

    public DbSet<Agent> Agents => Set<Agent>();
    public DbSet<InstalledAgent> InstalledAgents => Set<InstalledAgent>();
}
