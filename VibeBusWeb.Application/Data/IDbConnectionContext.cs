using Microsoft.EntityFrameworkCore;

namespace VibeBusWeb.Application.Data;

public interface IDbConnectionContext
{
    DbSet<Bus> Buses { get; set; }

    DbSet<City> Cities { get; set; }

    DbSet<Driver> Drivers { get; set; }

    DbSet<Route> Routes { get; set; }

    DbSet<Trip> Trips { get; set; }

    DbSet<User> Users { get; set; }
}