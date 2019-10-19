using System.Threading.Tasks;
using EnderstudyOAuthServer.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EnderstudyOAuthServer.Controllers
{
    [Route("register")]
    public class RegistrationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RegistrationController(
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
            User user = new User();
//            return View(user);
            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(
            [Bind("UserName,Email,PasswordHash")] User credentials    
        )
        {
            string password = credentials.PasswordHash;

            User newUser = new User
            {
                Email = credentials.Email,
                UserName = credentials.UserName,
                PasswordHash = _userManager.PasswordHasher.HashPassword(credentials, credentials.PasswordHash),
                LockoutEnabled = false
            };

            IdentityResult createResult = await _userManager.CreateAsync(newUser, password);
            if (createResult.Succeeded)
            {
                User user = await _userManager.FindByEmailAsync(credentials.Email);

                await _signInManager.PasswordSignInAsync(user, password, true, false);
//                return View(user);
                return Ok();
            }

//            return View(credentials);
            return Ok();
        }
    }
}