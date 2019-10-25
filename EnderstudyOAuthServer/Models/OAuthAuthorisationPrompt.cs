using System;
using System.Collections.Generic;
using EnderstudyOAuthServer.Data.Entities;

namespace EnderstudyOAuthServer.Models
{
    public class OAuthAuthorisationPrompt
    {
        public Application Application { get; set; }

        public User User { get; set; }

        public String RedirectUri { get; set; }
    }
}