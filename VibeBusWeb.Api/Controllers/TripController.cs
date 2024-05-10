using VibeBusWeb.Application.Data;
using VibeBusWeb.Database.Data;

namespace VibeBusWeb.Api.Controllers;

public class TripController : BaseController<Trip>
{
    public TripController(DbConnectionContext dbConnectionContext) : base(dbConnectionContext)
    {

    }
}