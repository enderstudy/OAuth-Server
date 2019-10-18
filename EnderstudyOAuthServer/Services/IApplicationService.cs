using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnderstudyOAuthServer.Data.Entities;

namespace EnderstudyOAuthServer.Services
{
    public interface IApplicationService
    {
        Task<ICollection<Application>> FindAllApplicationsAsync();

        Task<Application> FindByIdAsync(Guid id);

        Task<ICollection<Application>> FindByOwnerAsync(User user);
    }
}