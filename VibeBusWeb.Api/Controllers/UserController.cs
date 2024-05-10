using VibeBusWeb.Application.Data;
using VibeBusWeb.Database.Data;

namespace VibeBusWeb.Api.Controllers;

public class UserController : BaseController<User>
{
    public UserController(DbConnectionContext dbConnectionContext) : base(dbConnectionContext)
    {

    }
}