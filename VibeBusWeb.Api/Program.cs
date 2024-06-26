using Microsoft.EntityFrameworkCore;
using VibeBusWeb.Api;
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

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<DbConnectionContext>();
    dbContext.MigrateDatabase();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
