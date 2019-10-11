using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace EnderstudyOAuthServer.Data.Entities
{
    public class User : IdentityUser
    {
        public IEnumerable<UserApplication> AuthorisedApplications { get; set; }

        public ICollection<Application> PublishedApplications { get; set; }

        public ICollection<AuthorisationCodes> AuthorisationCodes { get; set; }

        public ICollection<AccessToken> AccessTokens { get; set; }
    }
}