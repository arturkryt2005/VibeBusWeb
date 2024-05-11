using Microsoft.AspNetCore.Components;
using VibeBusWeb.Services;
using VibeBusWeb.Application.Data;
using Route = VibeBusWeb.Application.Data.Route;

namespace VibeBusWeb.Pages;

public partial class EditTrip
{
	[Parameter]
	public int TripId { get; set; }

	[Inject]
	private RouteService RouteService { get; set; } = null!;

	[Inject]
	private CityService CityService { get; set; } = null!;

	[Inject]
	private UserService UserService { get; set; } = null!;

	[Inject]
	private NavigationManager NavigationManager { get; set; } = null!;

	private Route SelectedRoute { get; set; } = null!;

	private List<City> Cities { get; set; } = new();

	private int _selectedCityId;

	private int _selectedCityId2;

	private DateTime _departureDate = DateTime.Today;

	private DateTime _destinationDate = DateTime.Today;

	private string Message { get; set; } = "";

	protected override async Task OnInitializedAsync()
	{
		Cities = (await CityService.GetAllAsync()).ToList();
		SelectedRoute = (await RouteService.GetAllAsync()).FirstOrDefault(r => r.Id == TripId)!;
		StateHasChanged();
	}

	private void ChangeCity(ChangeEventArgs e)
	{
		if (int.TryParse(e.Value?.ToString(), out int cityId))
			SelectedRoute.DeparturePointId = cityId;
	}

	private void ChangeCity2(ChangeEventArgs e)
	{
		if (int.TryParse(e.Value?.ToString(), out int cityId))
			SelectedRoute.DestinationPointId = cityId;
	}

	private async Task AcceptBooking()
	{
		if (_destinationDate < _departureDate)
		{
			Message = "Дата прибытия не может быть раньше даты отправления.";
			return;
		}

		SelectedRoute.DeparturePoint = null!;
		SelectedRoute.DestinationPoint = null!;

		await RouteService.UpdateAsync(SelectedRoute);

		NavigationManager.NavigateTo("/Profile");
	}
}