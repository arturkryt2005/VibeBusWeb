using VibeBusWeb.Application.Data;
using VibeBusWeb.Database.Data;

namespace VibeBusWeb.Api.Controllers;

public class CityController : BaseController<City>
{
    public CityController(DbConnectionContext dbConnectionContext) : base(dbConnectionContext)
    {

    }
}