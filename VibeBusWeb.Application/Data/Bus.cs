using VibeBusWeb.Application.Data.Interfaces;

namespace VibeBusWeb.Application.Data;

public class Bus : IHaveId
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Number { get; set; } = null!;
}