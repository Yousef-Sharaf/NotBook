using Microsoft.EntityFrameworkCore;
using NotBook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotBook.Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionMember> SessionMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Session -> Host (User)
            // Deleting a user does NOT cascade-delete the sessions they host.
            // This also breaks the "multiple cascade paths" error, since without this,
            // SQL Server would see two ways to reach SessionMembers when deleting a User:
            //   1) User -> SessionMembers (direct)
            //   2) User -> Sessions (as host) -> SessionMembers
            modelBuilder.Entity<Session>()
                .HasOne(s => s.UserHost)
                .WithMany(u => u.HostedSessions)
                .HasForeignKey(s => s.UserHostId)
                .OnDelete(DeleteBehavior.Restrict);

            // Session -> SessionMembers
            // Deleting a session removes its memberships.
            modelBuilder.Entity<SessionMember>()
                .HasOne(sm => sm.Session)
                .WithMany(s => s.Members)
                .HasForeignKey(sm => sm.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> SessionMembers
            // Deleting a user removes their memberships.
            modelBuilder.Entity<SessionMember>()
                .HasOne(sm => sm.User)
                .WithMany(u => u.Memberships)
                .HasForeignKey(sm => sm.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SessionMember>()
                .HasIndex(sm => new { sm.SessionId, sm.UserId })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Session>()
                .Property(s => s.Title)
                .HasMaxLength(200);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(256);

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .HasMaxLength(512);
        }
    }
}
