using VibeBusWeb.Application.Data.Interfaces;

namespace VibeBusWeb.Application.Data;

public class City : IHaveId
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Region { get; set; } = null!;
}