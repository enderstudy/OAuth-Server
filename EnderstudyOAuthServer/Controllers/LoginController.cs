using System.Threading.Tasks;
using EnderstudyOAuthServer.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace EnderstudyOAuthServer.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginController(
            UserManager<User> userManager,
            SignInManager<User> signInManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(
            [Bind("Email,PasswordHash")] User userCredentials
        )
        {
            User user = await _userManager.FindByEmailAsync(userCredentials.Email);

            if (user == null)
            {
                return View(userCredentials);
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, userCredentials.PasswordHash, true, false);
            if (result.Succeeded)
            {
                return Redirect("/");
            }
            
            return View(userCredentials);
        }
    }
}