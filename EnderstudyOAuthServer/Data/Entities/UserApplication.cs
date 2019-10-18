using System;

namespace EnderstudyOAuthServer.Data.Entities
{
    public class UserApplication
    {
        public Guid Id { get; set; }
        public String UserId { get; set; }
        public User User { get; set; }
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}