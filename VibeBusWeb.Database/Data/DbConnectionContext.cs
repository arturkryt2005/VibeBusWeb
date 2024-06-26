﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using VibeBusWeb.Application.Data;

namespace VibeBusWeb.Database.Data;

public class DbConnectionContext : DbContext
{
    public DbConnectionContext(DbContextOptions<DbConnectionContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
	    optionsBuilder.UseLazyLoadingProxies();
	    optionsBuilder.ConfigureWarnings(x => x.Ignore(RelationalEventId.MultipleCollectionIncludeWarning));
    }

	public DbSet<Bus> Buses { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<Driver> Drivers { get; set; }

    public DbSet<Route> Routes { get; set; }

    public DbSet<Trip> Trips { get; set; }

    public DbSet<User> Users { get; set; }

    public void MigrateDatabase()
    {
        Database.Migrate();
    }
}