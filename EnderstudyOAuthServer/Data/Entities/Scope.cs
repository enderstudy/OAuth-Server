using System;
using System.Collections.Generic;

namespace EnderstudyOAuthServer.Data.Entities
{
    public class Scope
    {
        public Guid Id { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }

        public bool Dangerous { get; set; }
    }
}