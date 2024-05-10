using Microsoft.EntityFrameworkCore;
using VibeBusWeb.Database.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#if DEBUG
builder.Services.AddDbContext<DbConnectionContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#elif RELEASE
builder.Services.AddDbContext<DbConnectionContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ReleaseConnection")));
#endif

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
