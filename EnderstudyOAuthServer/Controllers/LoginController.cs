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
//            return View();
            return Ok();
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
                ViewBag.AlertType = "error";
                ViewBag.AlertContent = "Invalid Credentials";

                return Ok();
//                return View(userCredentials);
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, userCredentials.PasswordHash, true, false);
            if (result.Succeeded)
            {
                ViewBag.AlertType = "info";
                ViewBag.AlertContent = "Welcome back";
                return Redirect("/");
            }

            ViewBag.AlertType = "error";
            ViewBag.AlertContent = "Login failed - Reason: " + result.ToString();

            return Ok();
//            return View(userCredentials);
        }
    }
}