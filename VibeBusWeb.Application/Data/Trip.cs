using VibeBusWeb.Application.Data.Interfaces;

namespace VibeBusWeb.Application.Data;

public class Trip : IHaveId
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}