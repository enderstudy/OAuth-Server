using System;
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

        [Route("published")]
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

        [Route("register/official")]
        [HttpGet]
        public IActionResult RegisterOfficialApp()
        {
            Application application = new Application();
            return View(application);
        }

        [Route("register/official")]
        [HttpPost]
        public async Task<IActionResult> RegisterOfficialApp(
            [Bind("Name,Description,OwnerWebsite")]
            Application applicationData
        )
        {
            Application application = new Application
            {
                Name = applicationData.Name,
                Description = applicationData.Description,
                OwnerWebsite = applicationData.OwnerWebsite,
                Owner = await _userManager.GetUserAsync(User),
                IsOfficial = true,
                AuthorisedUsers = new List<UserApplication>(),
                CreatedAt = DateTime.Now
            };

            await _applicationService.SaveAsync(application);

            return RedirectToRoute("applications");
        }
    }
}