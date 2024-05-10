using VibeBusWeb.Application.Data;
using VibeBusWeb.Database.Data;

namespace VibeBusWeb.Api.Controllers;

public class BusController : BaseController<Bus>
{
    public BusController(DbConnectionContext dbConnectionContext) : base(dbConnectionContext)
    {

    }
}