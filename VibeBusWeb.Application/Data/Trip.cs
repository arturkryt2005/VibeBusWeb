using VibeBusWeb.Application.Data.Interfaces;

namespace VibeBusWeb.Application.Data;

public class Trip : IHaveId
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? BusId { get; set; }

    public virtual Bus? Bus { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }

    public int? RouteId { get; set; }

    public virtual Route? Route { get; set; }
}