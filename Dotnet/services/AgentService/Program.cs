using AgentService;
using AgentService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using AgentService.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AgentDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddScoped<AgentsService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

// Seed Data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AgentDbContext>();
    db.Database.Migrate();

    if (!db.Agents.Any())
    {
        db.Agents.AddRange(
            new AgentService.Models.Agent
            {
                Name = "Summarizer",
                Description = "Summarizes text",
                Endpoint = "/summarize",
                Method = "POST",
                InputSchema = "{ \"text\": \"string\" }",
                OutputSchema = "{ \"summary\": \"string\" }"
            },
            new AgentService.Models.Agent
            {
                Name = "TaskExtractor",
                Description = "Extracts tasks",
                Endpoint = "/extract-tasks",
                Method = "POST",
                InputSchema = "{ \"text\": \"string\" }",
                OutputSchema = "{ \"tasks\": [\"string\"] }"
            },
            new AgentService.Models.Agent
            {
                Name = "EmailGenerator",
                Description = "Generates email",
                Endpoint = "/generate-email",
                Method = "POST",
                InputSchema = "{ \"tasks\": [\"string\"] }",
                OutputSchema = "{ \"email\": \"string\" }"
            }
        );

        db.SaveChanges();
    }
}

app.Run();



