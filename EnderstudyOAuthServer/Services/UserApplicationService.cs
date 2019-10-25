using System.Threading.Tasks;
using EnderstudyOAuthServer.Data;
using EnderstudyOAuthServer.Data.Entities;

namespace EnderstudyOAuthServer.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly ApplicationDbContext _context;

        public UserApplicationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(UserApplication userApplication)
        {
            await _context.AddAsync(userApplication);
            await _context.SaveChangesAsync();
        }
    }
}