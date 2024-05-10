using VibeBusWeb.Application.Data;
using VibeBusWeb.Services.Bases;

namespace VibeBusWeb.Services;

public class BusService : BaseService<Bus>
{
    #if (DEBUG)

    protected override string BasePath => $"{nameof(Bus).ToLower()}";

    #elif (RELEASE)

    protected override string BasePath => $"vibe-bus/{nameof(Bus).ToLower()}";

    #endif

    public BusService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {

    }
}