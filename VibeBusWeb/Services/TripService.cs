using VibeBusWeb.Application.Data;
using VibeBusWeb.Services.Bases;

namespace VibeBusWeb.Services;

public class TripService : BaseService<Trip>
{
    #if (DEBUG)

    protected override string BasePath => $"{nameof(Trip).ToLower()}";

    #elif (RELEASE)

    protected override string BasePath => $"vibe-bus/{nameof(Trip).ToLower()}";

    #endif

    public TripService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {

    }
}