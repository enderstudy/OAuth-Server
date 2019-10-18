using System;

namespace EnderstudyOAuthServer.Data.Entities
{
    public class AccessTokenUsage
    {
        public Guid Id { get; set; }
        public AccessToken AccessToken { get; set; }

        public String Endpoint { get; set; }

        public DateTime DateCreated { get; set; }
    }
}