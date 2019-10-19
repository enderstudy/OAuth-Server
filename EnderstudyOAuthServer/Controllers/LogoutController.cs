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
        
        [Authorize]
        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            ViewBag.alert = new
            {
                type = "info",
                message = "You have been logged out"
            };

            await _signInManager.SignOutAsync();
            return Redirect("/login");
        }
    }
}