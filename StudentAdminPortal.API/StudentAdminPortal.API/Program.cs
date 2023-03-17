using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API;
using StudentAdminPortal.API.Profiles;
using StudentAdminPortal.API.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudentAdminContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("StudentAdminPortalDb")));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperProfiles)));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
