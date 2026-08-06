using Microsoft.EntityFrameworkCore;
using NotBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotBook.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<User> Users => Set<User>();
        public DbSet<Session> Sessions => Set<Session>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>()
                .HasOne(s => s.CreatedByUser)
                .WithMany(u => u.CreatedSessions)
                .HasForeignKey(s => s.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Session>()
                .HasIndex(s => s.JoinCode)
                .IsUnique();
        }
    }
}
