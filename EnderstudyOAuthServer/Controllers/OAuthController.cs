using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnderstudyOAuthServer.Data.Entities;
using EnderstudyOAuthServer.Models;
using EnderstudyOAuthServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EnderstudyOAuthServer.Controllers
{
    [Route("oauth")]
    public class OAuthController : Controller
    {
        private readonly IApplicationService _applicationService;
        private readonly IUserApplicationService _userApplicationService;
        private readonly UserManager<User> _userManager;

        public OAuthController(
            IApplicationService applicationService,
            IUserApplicationService userApplicationService,
            UserManager<User> userManager
        )
        {
            _applicationService = applicationService;
            _userApplicationService = userApplicationService;
            _userManager = userManager;
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Authorisation(
            [FromQuery(Name = "client_id")] Guid clientId,
            [FromQuery(Name = "scopes")] string[] scopes,
            [FromQuery(Name = "redirect_uri")] string redirectUri
        )
        {
            Application application = await _applicationService.FindByIdAsync(clientId);

            if (application == null)
            {
                throw new Exception("Application not found!");
            }

            OAuthAuthorisationPrompt prompt = new OAuthAuthorisationPrompt
            {
                Application = application,
                User = await _userManager.GetUserAsync(HttpContext.User),
                RedirectUri = redirectUri ?? application.OwnerWebsite
            };
            
            return View(prompt);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Authorisation(Guid applicationId, string redirectUri)
        {
            Application application = await _applicationService.FindByIdAsync(applicationId);
            User user = await _userManager.GetUserAsync(HttpContext.User);
            
            UserApplication grant = new UserApplication
            {
                UserId = user.Id,
                User = user,
                ApplicationId = applicationId,
                Application = application
            };

            await _userApplicationService.SaveAsync(grant);

            return Redirect(redirectUri);
        }
    }
}