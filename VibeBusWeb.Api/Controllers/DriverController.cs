using VibeBusWeb.Application.Data;
using VibeBusWeb.Database.Data;

namespace VibeBusWeb.Api.Controllers;

public class DriverController : BaseController<Driver>
{
    public DriverController(DbConnectionContext dbConnectionContext) : base(dbConnectionContext)
    {

    }
}