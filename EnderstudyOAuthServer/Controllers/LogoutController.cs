using System.Threading.Tasks;
using EnderstudyOAuthServer.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EnderstudyOAuthServer.Controllers
{
    [Authorize]
    [Route("logout")]
    public class LogoutController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LogoutController(
            UserManager<User> userManager,
            SignInManager<User> signInManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            return RedirectToRoute("Login");
        }
    }
}