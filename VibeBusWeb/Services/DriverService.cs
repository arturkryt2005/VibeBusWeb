using VibeBusWeb.Application.Data;
using VibeBusWeb.Services.Bases;

namespace VibeBusWeb.Services;

public class DriverService : BaseService<Driver>
{
    #if (DEBUG)

    protected override string BasePath => $"{nameof(Driver).ToLower()}";

    #elif (RELEASE)

    protected override string BasePath => $"vibe-bus/{nameof(Driver).ToLower()}";

    #endif

    public DriverService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {

    }
}