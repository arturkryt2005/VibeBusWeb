using VibeBusWeb.Application.Data.Interfaces;

namespace VibeBusWeb.Application.Data;

public class Route : IHaveId
{
    public int Id { get; set; }

    public DateTime DepartureTime { get; set; }

    public virtual City DeparturePoint { get; set; }

    public int DeparturePointId { get; set; }

    public virtual City DestinationPoint { get; set; }

	public int DestinationPointId { get; set; }

    public DateTime DestinationTime { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; }

    public int? DriverId { get; set; }

    public virtual Driver? Driver { get; set; }
}