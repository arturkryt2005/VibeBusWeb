using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using VibeBusWeb.Application.Data;
using VibeBusWeb.Services;

namespace VibeBusWeb.Pages;

public partial class EditPage
{
    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    private UserService UserService { get; set; } = null!;

    private User CurrentUser { get; set; } = null!;

    private List<User> Users { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        Users = (await UserService.GetAllAsync()).ToList();
        CurrentUser = UserService.CurrentUser;
    }

    private async Task SaveChanges()
    {
        if (CurrentUser.PhoneNumber.Length < 11)
        {
            await JSRuntime.InvokeVoidAsync("alert", "Номер телефона должен содержать как минимум 11 цифр.");
            return;
        }

        if (!CurrentUser.Email.Contains("@"))
        {
            await JSRuntime.InvokeVoidAsync("alert", "Некорректный адрес электронной почты.");
            return;
        }

        var existingUser = Users.FirstOrDefault(c => c.Id == CurrentUser.Id);

        await UserService.UpdateAsync(CurrentUser);
        
        CurrentUser = Users.FirstOrDefault(c => c.Id == existingUser!.Id)!;
        StateHasChanged();

        NavigationManager.NavigateTo("/Profile");
    }
}