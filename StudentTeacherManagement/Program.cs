using StudentTeacherManagement.Storage;
using Microsoft.EntityFrameworkCore;
using StudentTeacherManagement.Services;
using StudentTeacherManagement.Core.Interfaces;
using StudentTeacherManagement;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Local")));
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IStudentService, StudentService>();
//builder.Services.AddTransient<MyMiddleware>();
builder.Services.AddAutoMapper(typeof(Program));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
//app.UseMiddleware<MyMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();
