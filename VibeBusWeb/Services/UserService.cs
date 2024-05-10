using VibeBusWeb.Application.Data;
using VibeBusWeb.Services.Bases;

namespace VibeBusWeb.Services;

public class UserService : BaseService<User>
{
    public User CurrentUser { get; set; }

    #if (DEBUG)

    protected override string BasePath => $"{nameof(User).ToLower()}";

    #elif (RELEASE)

    protected override string BasePath => $"vibe-bus/{nameof(User).ToLower()}";

    #endif

    public UserService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {

    }
}