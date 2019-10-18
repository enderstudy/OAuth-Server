using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnderstudyOAuthServer.Data;
using EnderstudyOAuthServer.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnderstudyOAuthServer.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly ApplicationDbContext _context;

        public ApplicationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Application>> FindAllApplicationsAsync()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Application> FindByIdAsync(Guid id)
        {
            return await _context.Applications
                .Where(a => a.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public async Task<ICollection<Application>> FindByOwnerAsync(User user)
        {
            return await _context.Applications
                .Where(a => a.Owner.Equals(user))
                .ToListAsync();
        }
    }
}