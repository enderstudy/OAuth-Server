using System.Threading.Tasks;
using EnderstudyOAuthServer.Data.Entities;

namespace EnderstudyOAuthServer.Services
{
    public interface IUserApplicationService
    {
        Task SaveAsync(UserApplication userApplication);
    }
}