using VibeBusWeb.Database.Data;
using Route = VibeBusWeb.Application.Data.Route;

namespace VibeBusWeb.Api.Controllers;

public class RouteController : BaseController<Route>
{
    public RouteController(DbConnectionContext dbConnectionContext) : base(dbConnectionContext)
    {

    }
}