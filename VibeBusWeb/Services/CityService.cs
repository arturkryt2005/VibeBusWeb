using VibeBusWeb.Application.Data;
using VibeBusWeb.Services.Bases;

namespace VibeBusWeb.Services;

public class CityService : BaseService<City>
{
    #if (DEBUG)

    protected override string BasePath => $"{nameof(City).ToLower()}";

    #elif (RELEASE)

    protected override string BasePath => $"vibe-bus/{nameof(City).ToLower()}";

    #endif

    public CityService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {

    }
}