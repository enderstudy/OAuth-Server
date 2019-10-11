using System;
using System.Collections.Generic;

namespace EnderstudyOAuthServer.Data.Entities
{
    public class AccessToken
    {
        public Guid Id { get; set; }

        public User User { get; set; }

        public Application Application { get; set; }

        public ICollection<AccessTokenUsage> UsageEvents { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public DateTime LastUsed { get; set; }
    }
}