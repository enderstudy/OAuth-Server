using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EnderstudyOAuthServer.Data.Entities
{
    public class User : IdentityUser
    {
//        [Required(ErrorMessage = "You must provide a user name")]
//        public override string UserName { get; set; }
//
//        [Required(ErrorMessage = "You must provide an email address")]
//        [EmailAddress(ErrorMessage = "Must be a valid email address, with a valid extension")]
//        public override string Email { get; set; }
//
//        [Required(ErrorMessage = "You must provide a password")]
//        [StringLength(256, ErrorMessage = "Password must be 8 characters or longer"), MinLength(8)]
//        public override string PasswordHash { get; set; }

        public ICollection<UserApplication> AuthorisedApplications { get; set; }

        public ICollection<Application> PublishedApplications { get; set; }

        public ICollection<AuthorisationCode> AuthorisationCodes { get; set; }

        public ICollection<AccessToken> AccessTokens { get; set; }
    }
}