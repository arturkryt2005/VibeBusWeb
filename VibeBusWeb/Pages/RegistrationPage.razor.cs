using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using VibeBusWeb.Application.Data;
using UserService = VibeBusWeb.Services.UserService;

namespace VibeBusWeb.Pages;

public partial class RegistrationPage
{
    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    [Inject] 
    private UserService UserService { get; set; } = null!;

    private IEnumerable<User> Users { get; set; }

    private string _name = null!;

    private string _surname = null!;

    private string _email = null!;

    private string _phoneNumber = null!;

    private string _password = null!;

    private void RedirectToIndexPage()
    {
        NavigationManager.NavigateTo("/");
    }

    private async Task Register()
    {
        if (string.IsNullOrEmpty(_name) || string.IsNullOrEmpty(_surname) || string.IsNullOrEmpty(_email) || string.IsNullOrEmpty(_phoneNumber) || string.IsNullOrEmpty(_password))
        {
            await JSRuntime.InvokeVoidAsync("alert", "Пожалуйста, заполните все обязательные поля.");
            return;
        }

        if (!_email.Contains("@"))
        {
            await JSRuntime.InvokeVoidAsync("alert", "Некорректный адрес электронной почты.");
            return;
        }

        Users = await UserService.GetAllAsync();
        var existingUser = Users.FirstOrDefault(c => c.Email == _email);

        if (existingUser != null)
        {
            await JSRuntime.InvokeVoidAsync("alert", "По этой почте пользователь уже был зарегистрирован!");
            return;
        }

        var user = new User
        {
            Name = _name,
            Surname = _surname,
            Email = _email,
            PhoneNumber = _phoneNumber,
            Password = _password
        };

        await UserService.CreateAsync(user);

        NavigationManager.NavigateTo("/");
    }
}