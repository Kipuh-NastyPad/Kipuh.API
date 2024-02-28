using Kipuh.API.Kipuh.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v0", new OpenApiInfo
    {
        Version = "v1",
        Title = "Kipuh.API",
        Description = "Kipuh.API v0. Nasty Pad💎",
    });
    options.EnableAnnotations();
});

// Connection String
var connectionString = builder.Configuration.GetConnectionString("KipuhDBConnection");

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
    {
        if (connectionString != null)
        {
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 35)))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// CORS
builder.Services.AddCors();

// Services

// Shared Services

// Automapper Services

var app = builder.Build();

// Validation to ensuring database tables were created.
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context?.Database.EnsureDeleted();
    context?.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v0/swagger.json", "v0");
        options.RoutePrefix = "swagger";
    });
}

app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthorization();
app.Run();