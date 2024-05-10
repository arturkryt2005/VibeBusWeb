using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using VibeBusWeb.Application.Data;
using VibeBusWeb.Services;

namespace VibeBusWeb.Pages;

public partial class Index
{
    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    private UserService UserService { get; set; } = null!;

    private List<User> Users { get; set; } = null!;

    private string _email = null!;

    private string _password = null!;

    protected override async Task OnInitializedAsync()
    {
        Users = (await UserService.GetAllAsync()).ToList();
    }

    private void RedirectToRegistrationPage()
    {
        NavigationManager.NavigateTo("/RegistrationPage");
    }
    
    private async Task Login()
    {
        if (string.IsNullOrEmpty(_email) || string.IsNullOrEmpty(_password))
        {
            await JSRuntime.InvokeVoidAsync("alert", "Пожалуйста, заполните все обязательные поля.");
            return;
        }

        var user = Users.FirstOrDefault(u => u.Email == _email && u.Password == _password);

        if (user != null)
        {
            UserService.CurrentUser = user;
            NavigationManager.NavigateTo("/Profile");
        }
        else
        {
            await JSRuntime.InvokeVoidAsync("alert", "Неверный адрес электронной почты или пароль.");
        }
    }
}