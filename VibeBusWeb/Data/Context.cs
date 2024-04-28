using Microsoft.EntityFrameworkCore;

namespace VibeBusWeb.Data
{
    public class Buses
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Number { get; set; } = null!;
    }

    public class Cities
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Region { get; set; } = null!;
    }

    public class Drivers
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class Routes
    {
        public int Id { get; set; }
        public string DepartureTime { get; set; } = null!;
        public string DestinationTime { get; set; } = null!;
    }

    public class Trips
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Surname { get; set; } = null!;
    }

    public class DbConnectionContext : DbContext
    {
        public DbConnectionContext(DbContextOptions<DbConnectionContext> options)
        : base(options)
        {
        }

        public DbSet<Buses> Buses { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Drivers> Drivers { get; set; }
        public DbSet<Routes> Routes { get; set; }
        public DbSet<Trips> Trips { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
