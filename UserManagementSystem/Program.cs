global using UserManagementSystem.Models;
using UserManagementSystem;
using UserManagementSystem.Data;
using UserManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add other services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Welcome
app.MapGet("/", () =>
{
    return "Bem-vindo ao INDT challenge api!";
})
.WithName("GetWelcomeRoute").WithOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
