using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VibeBusWeb.Data;

namespace VibeBusWeb
{
    public class UserService
    {
        private readonly DbConnectionContext _dbContext;

        public Users CurrentUser { get; set; } = null!;

        public UserService(DbConnectionContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Routes>> GetUserTripsAsync(string userId)
        {
            if (int.TryParse(userId, out int parsedUserId))
            {
                return await _dbContext.Routes
                    .Where(r => r.UserId == parsedUserId && r.UserId != 0)
                    .ToListAsync();
            }
            else
            {
                return new List<Routes>();
            }
        }

    }
}
