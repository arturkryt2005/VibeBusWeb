using Microsoft.AspNetCore.Components;
using VibeBusWeb.Application.Data;
using VibeBusWeb.Services;
using Route = VibeBusWeb.Application.Data.Route;

namespace VibeBusWeb.Pages;

public partial class Profile
{
    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    private UserService UserService { get; set; } = null!;

    [Inject]
    private RouteService RouteService { get; set; } = null!;

    [Inject]
    private CityService CityService { get; set; } = null!;

    private User CurrentUser { get; set; } = null!;

    private List<Route> Routes { get; set; } = null!;

    private List<City> Cities { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        Cities = (await CityService.GetAllAsync()).ToList();

        CurrentUser = UserService.CurrentUser;

        if (CurrentUser != null)
        {
            Routes = (await RouteService.GetAllAsync())
                .Where(r => r.UserId == CurrentUser.Id)
                .ToList();
        }
    }
        
    private void EditProfile()
    {
        NavigationManager.NavigateTo("/EditPage");
    }

    private void Cancel()
    {
        NavigationManager.NavigateTo("/");
    }

    private async Task NavigateToTrip(int tripId)
    {
        NavigationManager.NavigateTo($"/edit-trip/{tripId}");
    }
}