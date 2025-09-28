using Microsoft.EntityFrameworkCore;
using TaskBoard.Application;
using TaskBoard.Application.Mapping;
using TaskBoard.Domain;
using TaskBoard.Infrastructure;
using TaskBoard.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddCustomApplicationServices();

var autoMapperLicenseKey = Environment.GetEnvironmentVariable("AUTOMAPPER_LICENSE_KEY");
builder.Services.AddAutoMapper(cfg =>
{
    cfg.LicenseKey = autoMapperLicenseKey;
}, typeof(BaseProfile));

builder.Services.AddDbContext<TaskBoardDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
