using VibeBusWeb.Application.Data.Interfaces;

namespace VibeBusWeb.Application.Data;

public class Route : IHaveId
{
    public int Id { get; set; }

    public DateTime DepartureTime { get; set; }

    public int DeparturePointId { get; set; }

    public int DestinationPointId { get; set; }

    public DateTime DestinationTime { get; set; }

    public int UserId { get; set; }

    public virtual User Users { get; set; }
}