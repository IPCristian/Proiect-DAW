using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proiect.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Data
{
    public class AuthentificationContext : IdentityDbContext<StandardUser, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public AuthentificationContext(DbContextOptions options) : base(options) { }
        public DbSet<SessionToken> SessionTokens { get; set; }

        public DbSet<User> MUsers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()                 // One user has more playlists
               .HasMany(a => a.Playlists)              // A playlist is made only by one user
               .WithOne(b => b.User);

            modelBuilder.Entity<User>()                 // One user only has one subscription 
                .HasOne(u => u.Subscription)            // A subscription is owned only by one user
                .WithOne(sub => sub.User);

            modelBuilder.Entity<PlaylistSong>().HasKey(ps => new { ps.PlaylistId, ps.SongId });

            modelBuilder.Entity<PlaylistSong>()         // Many to many extra table
                .HasOne(ps => ps.Song)
                .WithMany(a => a.PlaylistSongs)
                .HasForeignKey(ps => ps.SongId);

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Playlist)
                .WithMany(a => a.PlaylistSongs)
                .HasForeignKey(ps => ps.PlaylistId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.StandardUser).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);

            });
        }
    }
}
