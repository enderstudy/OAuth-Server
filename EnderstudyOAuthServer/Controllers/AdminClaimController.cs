using System.Threading.Tasks;
using EnderstudyOAuthServer.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EnderstudyOAuthServer.Controllers
{
    [Route("claim-admin")]
//    [Authorize(Roles = "Administrator")]
    public class AdminClaimController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AdminClaimController(
            UserManager<User> userManager,
            SignInManager<User> signInManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [Authorize]
        public async Task<IActionResult> Index()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return Forbid();
            }

            await _userManager.AddToRoleAsync(user, "Administrator");
            await _userManager.UpdateAsync(user);
            return Ok();
        }
    }
}