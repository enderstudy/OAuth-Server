using System;

namespace EnderstudyOAuthServer.Data.Entities
{
    public class ApplicationScope
    {
        public Guid ApplicationId { get; set; }

        public Application Application { get; set; }

        public Guid ScopeId { get; set; }

        public Scope Scope { get; set; }
    }
}