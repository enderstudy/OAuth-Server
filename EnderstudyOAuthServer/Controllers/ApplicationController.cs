using System.Collections.Generic;
using System.Threading.Tasks;
using EnderstudyOAuthServer.Data.Entities;
using EnderstudyOAuthServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EnderstudyOAuthServer.Controllers
{
    [Route("applications")]
    [Authorize]
    public class ApplicationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IApplicationService _applicationService;

        public ApplicationController(
            IApplicationService applicationService, 
            UserManager<User> userManager
        )
        {
            _userManager = userManager;
            _applicationService = applicationService;
        }

        public async Task<IActionResult> PublishedApplications()
        {
            User user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return View();
            }

            ICollection<Application> publishedApplications = await _applicationService.FindByOwnerAsync(user);

            if (publishedApplications == null)
            {
                return View();
            }

            return View(publishedApplications);
        }
    }
}