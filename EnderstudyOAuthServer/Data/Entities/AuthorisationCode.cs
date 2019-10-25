using System;

namespace EnderstudyOAuthServer.Data.Entities
{
    public class AuthorisationCodes
    {
        public Guid Id { get; set; }

        public String Code { get; set; }

        public User User { get; set; }

        public Application Application { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UsedAt { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}