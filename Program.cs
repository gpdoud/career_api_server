using career_api_server.Models;
using Microsoft.EntityFrameworkCore;

// select the proper connection string

var connStrKey = "CareerDbContext";
#if DOCKER
connStrKey += "Docker";
#elif RIPPER
connStrKey += "Ripper";
#elif DEBUGRELEASE
connStrKey += "DebugRelease";
#endif

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CareerDbContext>(
    x => x.UseSqlServer(builder.Configuration.GetConnectionString("CareerDbContextDocker"))
);

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();

