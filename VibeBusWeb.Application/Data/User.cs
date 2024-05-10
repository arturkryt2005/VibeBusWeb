﻿namespace VibeBusWeb.Application.Data;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    
    public string Surname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;
}