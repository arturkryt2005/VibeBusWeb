using VibeBusWeb.Application.Data;
using VibeBusWeb.Services.Bases;
using Route = VibeBusWeb.Application.Data.Route;

namespace VibeBusWeb.Services;

public class RouteService : BaseService<Route>
{
    #if (DEBUG)

    protected override string BasePath => $"{nameof(Route).ToLower()}";

    #elif (RELEASE)

    protected override string BasePath => $"vibe-bus/{nameof(Route).ToLower()}";

    #endif

    public RouteService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {

    }
}