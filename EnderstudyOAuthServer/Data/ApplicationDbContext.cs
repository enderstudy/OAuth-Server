using System;
using System.Collections.Generic;
using System.Text;
using EnderstudyOAuthServer.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnderstudyOAuthServer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<AuthorisationCodes> AuthorisationCodes { get; set; }
        public DbSet<AccessToken> AccessTokens { get; set; }
        public DbSet<AccessTokenUsage> AccessTokenUsageEvents { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(user =>
            {
                user.HasMany(u => u.PublishedApplications)
                    .WithOne(a => a.Owner);
                
                user.HasMany(u => u.AccessTokens)
                    .WithOne(at => at.User);

                user.HasMany(u => u.AuthorisationCodes)
                    .WithOne(ac => ac.User);
            });

            builder.Entity<UserApplication>(userApplication =>
            {
                userApplication.HasKey(ua => new {ua.UserId, ua.ApplicationId});
                
                userApplication.HasOne(ua => ua.User)
                    .WithMany(u => u.AuthorisedApplications)
                    .HasForeignKey(ua => ua.UserId);
                
                userApplication.HasOne(ua => ua.Application)
                    .WithMany(a => a.AuthorisedUsers)
                    .HasForeignKey(ua => ua.ApplicationId);
            });

            builder.Entity<AccessToken>(accessToken =>
            {
                accessToken.HasOne(at => at.User)
                    .WithMany(u => u.AccessTokens);

                accessToken.HasMany(at => at.UsageEvents)
                    .WithOne(atu => atu.AccessToken);
            });
        }
    }
}