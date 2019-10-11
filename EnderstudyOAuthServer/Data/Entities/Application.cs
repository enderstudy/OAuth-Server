using System;
using System.Collections.Generic;

namespace EnderstudyOAuthServer.Data.Entities
{
    public class Application
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String OwnerWebsite { get; set; }

        public Boolean IsOfficial { get; set; }

        public User Owner { get; set; }

        public IEnumerable<UserApplication> AuthorisedUsers { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}