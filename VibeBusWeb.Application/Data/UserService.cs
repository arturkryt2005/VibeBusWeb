using Microsoft.EntityFrameworkCore;

namespace VibeBusWeb.Application.Data
{
    public class UserService
    {
        private readonly IDbConnectionContext _dbContext;

        public User CurrentUser { get; set; } = null!;

        public UserService(IDbConnectionContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Route>> GetUserTripsAsync(string userId)
        {
            if (int.TryParse(userId, out int parsedUserId))
            {
                return await _dbContext.Routes
                    .Where(r => r.UserId == parsedUserId && r.UserId != 0)
                    .ToListAsync();
            }
            else
            {
                return new List<Route>();
            }
        }

    }
}
