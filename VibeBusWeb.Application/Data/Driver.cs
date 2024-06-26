﻿using VibeBusWeb.Application.Data.Interfaces;

namespace VibeBusWeb.Application.Data;

public class Driver : IHaveId
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? BusId { get; set; }

    public virtual Bus? Bus { get; set; }
}