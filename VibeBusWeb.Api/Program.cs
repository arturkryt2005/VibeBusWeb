using Microsoft.EntityFrameworkCore;
using VibeBusWeb.Database.Data;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    #if RELEASE
    options.DocumentFilter<PrefixDocumentFilter>();
    #endif
});

#if DEBUG
    builder.Services.AddDbContext<DbConnectionContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")!));
#elif RELEASE
    builder.Services.AddDbContext<DbConnectionContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ReleaseConnection")!));
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
