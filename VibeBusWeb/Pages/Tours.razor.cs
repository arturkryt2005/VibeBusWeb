using Microsoft.AspNetCore.Components;
using VibeBusWeb.Application.Data;
using VibeBusWeb.Services;
using Route = VibeBusWeb.Application.Data.Route;

namespace VibeBusWeb.Pages;

public partial class Tours
{
    [Parameter]
    public string ApplicationTicketId { get; set; } = null!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    private UserService UserService { get; set; } = null!;

    [Inject]
    private RouteService RouteService { get; set; } = null!;

    [Inject]
    private CityService CityService { get; set; } = null!;

    private List<City> _cities = new();

    private int _selectedCityId;

    private int _selectedCityId2;

    private DateTime _departureDate = DateTime.Today;

    private DateTime _destinationDate = DateTime.Today;

    private string Message { get; set; } = "";

    private async Task AcceptBooking()
    {
        if (_destinationDate < _departureDate)
        {
            Message = "Дата прибытия не может быть раньше даты отправления.";
            return;
        }

        var selectedRoute = new Route
        {
            DeparturePointId = _selectedCityId,
            DestinationPointId = _selectedCityId2,
            DepartureTime = _departureDate,
            DestinationTime = _destinationDate,
            UserId = UserService.CurrentUser?.Id ?? 0
        };

        await RouteService.CreateAsync(selectedRoute);

        var selectedCity = _cities.FirstOrDefault(c => c.Id == _selectedCityId)?.Name;
        var result = await emailService.SendMessage(selectedCity, _departureDate);

        if (result.Success)
            NavigationManager.NavigateTo("/Profile");
        else
            Message = $"Ошибка при отправке письма: {result.ErrorMessage}";
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadCities();
    }

    private async Task LoadCities()
    {
        _cities = (await CityService.GetAllAsync()).ToList();

        if (_cities.Any())
        {
            _selectedCityId = _cities.First().Id;
            _selectedCityId2 = _cities.Last().Id;
        }

        StateHasChanged();
    }

    private void ChangeCity(ChangeEventArgs e)
    {
        if (int.TryParse(e.Value?.ToString(), out int cityId))
        {
            _selectedCityId = cityId;
        }
    }

    private void ChangeCity2(ChangeEventArgs e)
    {
        if (int.TryParse(e.Value?.ToString(), out int cityId))
        {
            _selectedCityId2 = cityId;
        }
    }
}