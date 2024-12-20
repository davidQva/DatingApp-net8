using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddCors(options =>
     {
         options.AddPolicy("CorsPolicy",
             policy => policy.WithOrigins("http://127.0.0.1:4200","https://127.0.0.1:4200")
                           .AllowAnyMethod()
                           .AllowAnyHeader());
     });


var app = builder.Build();
app.UseCors("CorsPolicy");

//Configure the HTTP request piplene

app.MapControllers();

app.Run();
